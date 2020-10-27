﻿using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Purefolio_backend.Services
{
    public class BaseDataService
    {
        private readonly ILogger<BaseDataService> _logger;
        private readonly IDatabaseStore ds;
        private BaseData baseData;
        public BaseDataService(ILogger<BaseDataService> _logger,
            IDatabaseStore ds,
            BaseData baseData)
        {
            this._logger = _logger;
            this.ds = ds;
            this.baseData = baseData;
        }
        public string PopulateDatabase()
        {
            List<Nace> savedNaces = ds.getAllNaces();
            List<Region> savedRegions = ds.getAllRegions();
            List<EuroStatTable> savedTables = ds.getAllEuroStatTables();
            foreach(Nace nace in baseData.getAllNaces())
            {
                try
                { 
                    if(!savedNaces.Contains(nace)){
                        ds.createNace(nace);
                    }
                    
                } catch(Exception exception)
                {
                    _logger.LogError(exception.ToString());
                    return exception.ToString();
                }
            }
            foreach(Region region in baseData.getAllRegions())
            {
                try
                { 
                    if(!savedRegions.Contains(region)){
                        ds.createRegion(region);
                    }
                } catch(Exception exception)
                {
                    _logger.LogError(exception.ToString());
                    return exception.ToString();
                }
            }
            foreach(EuroStatTable table in baseData.getAllEuroStatTables())
            {
                try
                { 
                    if(!savedTables.Contains(table)){
                        ds.createEuroStatTable(table);
                    }
                } catch(Exception exception)
                {
                    _logger.LogError(exception.ToString());
                    return exception.ToString();
                }
            }
            return "The base data was added successfully";
        }
    }
}
