using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using MLCL.Model;

namespace MLCL.Services
{
    public class MLService
    {
        private readonly string url = "URL DO SERVIÇO";
        private readonly string apiKey = "CHAVE DO SERVIÇO";

        HttpClient _client;

        public async Task<RespostaString> MLServico(MLModelo modelo)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            _client.BaseAddress = new Uri(url);

            var json = JsonConvert.SerializeObject(modelo);
            var stringCont = new StringContent(json, Encoding.UTF8, "application/json");
            var resposta = await _client.PostAsync("", stringCont);

            if (resposta.IsSuccessStatusCode)
            {
                var resultado = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RespostaString>(resultado);
            }

            else
            {
                string Erro = (string.Format($"The request failed with status code: {resposta.StatusCode}"));
                await App.Current.MainPage.DisplayAlert("Erro", Erro, "ok");
            }
            return null;
        }

        public async Task<RespostaString> MLServicoExemploAsync()
        {
            _client = new HttpClient();
            var scoreRequest = new
            {
                Inputs = new Dictionary<string, List<Dictionary<string, string>>>() {
                        {
                            "input1",
                            new List<Dictionary<string, string>>(){new Dictionary<string, string>(){
                                            {
                                                "Relative Compactness", "0.98"
                                            },
                                            {
                                                "Surface Area", "514.5"
                                            },
                                            {
                                                "Wall Area", "294"
                                            },
                                            {
                                                "Roof Area", "110.25"
                                            },
                                            {
                                                "Overall Height", "7"
                                            },
                                            {
                                                "Orientation", "2"
                                            },
                                            {
                                                "Glazing Area", "0"
                                            },
                                            {
                                                "Glazing Area Distribution", "0"
                                            },
                                            {
                                                "Heating Load", "15.55"
                                            },
                                            {
                                                "Cooling Load", "" //21.33
                                            },
                                }
                            }
                        },
                    },
                GlobalParameters = new Dictionary<string, string>()
                {
                }
            };

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            _client.BaseAddress = new Uri(url);
            var json = JsonConvert.SerializeObject(scoreRequest);
            HttpResponseMessage response = await _client.PostAsync("", new StringContent(json, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RespostaString>(resultado);
                
            }

            return null;
        }
        
    }
}
