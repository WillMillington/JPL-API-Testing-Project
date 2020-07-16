﻿using System.Collections.Generic;
using JPL_API_Testing.CadApi.CadApiService.DataHandling;
using JPL_API_Testing.JPLAPIService.DataHandling;
using JPL_API_Testing.JPLAPIService.HTTPManager;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JPL_API_Testing.JPLAPIService
{
    public class APIService
    {
        public APIManager cadManager = new APIManager();
        public APIDTO cadDTO = new APIDTO();
        public List<CADKeyValues> cadDataList;
        public string cadData;
        public JObject json_cad;

        public APIService()
        {
            cadData = cadManager.GetCloseApproachData();
            cadDTO.DeserializeCADData(cadData);
            json_cad = JsonConvert.DeserializeObject<JObject>(cadData);
            cadDataList = GetCADData();
        }
        private List<CADKeyValues> GetCADData() => cadDTO.ConvertToList();
    }
}