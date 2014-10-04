﻿using System;
using Nest;

namespace log4net.ElasticSearch.Tests
{
    public abstract class ElasticSearchTestSetup
    {
        private readonly ConnectionSettings elasticSettings;
        private readonly string testIndex;

        protected readonly ElasticClient client;

        protected ElasticSearchTestSetup()
        {
            testIndex = string.Format("{0}-{1}", "log_test", DateTime.Now.ToString("yyyy.MM.dd"));

            elasticSettings = new ConnectionSettings(new Uri("http://127.0.0.1:9200"))
                .SetDefaultIndex(testIndex);
            
            client = new ElasticClient(elasticSettings);

            client.DeleteIndex(new DeleteIndexRequest(testIndex));
        }

        protected void DeleteTestIndex()
        {
            client.DeleteIndex(new DeleteIndexRequest(testIndex));
        }
    }
}
