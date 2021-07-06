﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TranslateApplication.Models;

namespace TranslateApplication.Services
{
    public class ApiService
    {
        string YANDEX_BASE_URL = "https://translate.yandex.net/api/v1.5/tr.json/translate";
        string YANDEX_API_KEY = YOUR YANDEX API KEY;

        string COLLECT_BASE_URL = "https://api.collectapi.com/dictionary/wordSearchTurkish?query=";
        string COLLECT_API_KEY = "apikey YOUR COLLECT API KEY";

        HttpClient client = new HttpClient();
        public async Task<YandexApiModel> GetWordAsync(string word, string lang, string langTo)
        {

            var result = await client.GetStringAsync(YANDEX_BASE_URL + "?key=" + YANDEX_API_KEY + "&text=" + word + "&lang="+ langTo+ "-" + lang);
            var response = JsonConvert.DeserializeObject<YandexApiModel>(result); 
            return response;
        }

        public async Task<TdkApiModel> GetDetailAsync(string word)
        {
            var response = await GetWordAsync(word, "tr", "en");
            var clientTdk = new RestClient(COLLECT_BASE_URL + response.text[0]);
            var requestTdk = new RestRequest(Method.GET);
            requestTdk.AddHeader("authorization", COLLECT_API_KEY);
            requestTdk.AddHeader("content-type", "application/json");
            IRestResponse responseTdk = clientTdk.Execute(requestTdk);
            var tdkResponse = JsonConvert.DeserializeObject<TdkApiModel>(responseTdk.Content);
            return tdkResponse;
        }
    }
}
