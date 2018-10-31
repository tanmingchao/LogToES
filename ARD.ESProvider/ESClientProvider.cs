/*******************************************************************
*	命名空间 ：ARD.ESProvider
*	文件名称 ：ESClientProvider
*	创 建 人 ：m1835
*	创建日期 ：2018/8/9 20:28:57
*   -------------------------------------------------------------
*	Copyright @ m1835 2018. All rights reserved.
*******************************************************************/
using Microsoft.Extensions.Options;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace ARD.ESProvider
{
    public class ESClientProvider<T> where T : class
    {
        public ESClientProvider(IOptions<ESOptions> options)
        {
            var settings = new ConnectionSettings(new Uri(options.Value.Uri))
                .DefaultIndex(options.Value.DefaultIndex);

            if (!String.IsNullOrEmpty(options.Value.UserName) && !String.IsNullOrEmpty(options.Value.Password))
            {
                settings.BasicAuthentication(options.Value.UserName, options.Value.Password);
            }

            this.Client = new ElasticClient(settings);
            this.DefaultIndex = options.Value.DefaultIndex;
            EnsureIndexWithMapping(this.DefaultIndex);
        }

        public ElasticClient Client { get; private set; }
        public string DefaultIndex { get; set; }

        public void EnsureIndexWithMapping(string indexName = null, Func<PutMappingDescriptor<T>, PutMappingDescriptor<T>> customMapping = null)
        {
            if (String.IsNullOrEmpty(indexName)) indexName = this.DefaultIndex;

            // Map type T to that index
            this.Client.ConnectionSettings.DefaultIndices.Add(typeof(T), indexName);

            // Does the index exists?
            var indexExistsResponse = this.Client.IndexExists(new IndexExistsRequest(indexName));
            if (!indexExistsResponse.IsValid) throw new InvalidOperationException(indexExistsResponse.DebugInformation);

            // If exists, return
            if (indexExistsResponse.Exists) return;

            // Otherwise create the index and the type mapping
            var createIndexRes = this.Client.CreateIndex(indexName);
            if (!createIndexRes.IsValid) throw new InvalidOperationException(createIndexRes.DebugInformation);

            var res = this.Client.Map<T>(m =>
            {
                m.AutoMap().Index(indexName);
                if (customMapping != null) m = customMapping(m);
                return m;
            });

            if (!res.IsValid) throw new InvalidOperationException(res.DebugInformation);
        }
    }
}
