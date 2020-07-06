// COMPILER GENERATED CODE
// THIS WILL BE OVERWRITTEN AT EACH GENERATION
// EDIT AT YOUR OWN RISK

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ECAClientFramework;
using ECAClientUtilities;
using ECACommonUtilities;
using ECACommonUtilities.Model;
using GSF.TimeSeries;
using SSDQopenECA.Model.GPA;

namespace SSDQopenECA.Model
{
    [CompilerGenerated]
    public class Unmapper : UnmapperBase
    {
        #region [ Constructors ]

        public Unmapper(Framework framework, MappingCompiler mappingCompiler)
            : base(framework, mappingCompiler, SystemSettings.OutputMapping)
        {
            Algorithm.Output.CreateNew = () => new Algorithm.Output()
            {
                OutputData = FillOutputData(),
                OutputMeta = FillOutputMeta()
            };
        }

        #endregion

        #region [ Methods ]

        public SSDQopenECA.Model.GPA.Out_Data FillOutputData()
        {
            TypeMapping outputMapping = MappingCompiler.GetTypeMapping(OutputMapping);
            Reset();
            return FillGPAOut_Data(outputMapping);
        }

        public SSDQopenECA.Model.GPA._Out_DataMeta FillOutputMeta()
        {
            TypeMapping outputMeta = MappingCompiler.GetTypeMapping(OutputMapping);
            Reset();
            return FillGPA_Out_DataMeta(outputMeta);
        }

        public IEnumerable<IMeasurement> Unmap(SSDQopenECA.Model.GPA.Out_Data outputData, SSDQopenECA.Model.GPA._Out_DataMeta outputMeta)
        {
            List<IMeasurement> measurements = new List<IMeasurement>();
            TypeMapping outputMapping = MappingCompiler.GetTypeMapping(OutputMapping);

            CollectFromGPAOut_Data(measurements, outputMapping, outputData, outputMeta);

            return measurements;
        }

        private SSDQopenECA.Model.GPA.Out_Data FillGPAOut_Data(TypeMapping typeMapping)
        {
            Dictionary<string, FieldMapping> fieldLookup = typeMapping.FieldMappings.ToDictionary(mapping => mapping.Field.Identifier);
            SSDQopenECA.Model.GPA.Out_Data obj = new SSDQopenECA.Model.GPA.Out_Data();

            //Modified by Tapas for dynamic Mapping 
            if (FrameworkConfiguration.newframework)
            {
                int count = Algorithm.New_config.Inentrynamelist.Count();
                for (int i = 0; i < count; i++)
                {
                    {
                        // We don't need to do anything, but we burn a key index to keep our
                        // array index in sync with where we are in the data structure
                        BurnKeyIndex();
                    }


                }
            }
            else
            {
                int count = Algorithm.Stored_config.Inentrynamelist.Count();
                for (int i = 0; i < count; i++)
                {
                    {
                        // We don't need to do anything, but we burn a key index to keep our
                        // array index in sync with where we are in the data structure
                        BurnKeyIndex();
                    }


                }
            }

            ////Auto Generated(GPA) code while creation of project for the first time
            //{
            //    // We don't need to do anything, but we burn a key index to keep our
            //    // array index in sync with where we are in the data structure
            //    BurnKeyIndex();
            //}

            //{
            //    // We don't need to do anything, but we burn a key index to keep our
            //    // array index in sync with where we are in the data structure
            //    BurnKeyIndex();
            //}

            //{
            //    // We don't need to do anything, but we burn a key index to keep our
            //    // array index in sync with where we are in the data structure
            //    BurnKeyIndex();
            //}

            //{
            //    // We don't need to do anything, but we burn a key index to keep our
            //    // array index in sync with where we are in the data structure
            //    BurnKeyIndex();
            //}

            //{
            //    // We don't need to do anything, but we burn a key index to keep our
            //    // array index in sync with where we are in the data structure
            //    BurnKeyIndex();
            //}

            //{
            //    // We don't need to do anything, but we burn a key index to keep our
            //    // array index in sync with where we are in the data structure
            //    BurnKeyIndex();
            //}

            //{
            //    // We don't need to do anything, but we burn a key index to keep our
            //    // array index in sync with where we are in the data structure
            //    BurnKeyIndex();
            //}

            //{
            //    // We don't need to do anything, but we burn a key index to keep our
            //    // array index in sync with where we are in the data structure
            //    BurnKeyIndex();
            //}

            //{
            //    // We don't need to do anything, but we burn a key index to keep our
            //    // array index in sync with where we are in the data structure
            //    BurnKeyIndex();
            //}

            //{
            //    // We don't need to do anything, but we burn a key index to keep our
            //    // array index in sync with where we are in the data structure
            //    BurnKeyIndex();
            //}

            //{
            //    // We don't need to do anything, but we burn a key index to keep our
            //    // array index in sync with where we are in the data structure
            //    BurnKeyIndex();
            //}

            return obj;
        }

        private SSDQopenECA.Model.GPA._Out_DataMeta FillGPA_Out_DataMeta(TypeMapping typeMapping)
        {
            Dictionary<string, FieldMapping> fieldLookup = typeMapping.FieldMappings.ToDictionary(mapping => mapping.Field.Identifier);
            SSDQopenECA.Model.GPA._Out_DataMeta obj = new SSDQopenECA.Model.GPA._Out_DataMeta();

            //Modified by Tapas for dynamic Mapping 
            if (FrameworkConfiguration.newframework)
            {
                int count = Algorithm.New_config.Outentrynamelist.Count();
                for (int i = 0; i < count; i++)
                {
                    FieldMapping fieldMapping = fieldLookup[Algorithm.New_config.Outentrynamelist[i]];
                    obj.GetType().GetProperty(Algorithm.New_config.Outentrynamelist[i]).SetValue(obj, CreateMetaValues(fieldMapping));

                }
            }
            else
            {
                int count = Algorithm.Stored_config.Outentrynamelist.Count();
                for (int i = 0; i < count; i++)
                {
                    FieldMapping fieldMapping = fieldLookup[Algorithm.Stored_config.Outentrynamelist[i]];
                    obj.GetType().GetProperty(Algorithm.Stored_config.Outentrynamelist[i]).SetValue(obj, CreateMetaValues(fieldMapping));

                }
            }

            ////Auto Generated(GPA) code while creation of project for the first time
            //{
            //    // Initialize meta value structure to "Out_Entry1" field
            //    FieldMapping fieldMapping = fieldLookup["Out_Entry1"];
            //    obj.Out_Entry1 = CreateMetaValues(fieldMapping);
            //}

            //{
            //    // Initialize meta value structure to "Out_Entry2" field
            //    FieldMapping fieldMapping = fieldLookup["Out_Entry2"];
            //    obj.Out_Entry2 = CreateMetaValues(fieldMapping);
            //}

            //{
            //    // Initialize meta value structure to "Out_Entry3" field
            //    FieldMapping fieldMapping = fieldLookup["Out_Entry3"];
            //    obj.Out_Entry3 = CreateMetaValues(fieldMapping);
            //}

            //{
            //    // Initialize meta value structure to "Out_Entry4" field
            //    FieldMapping fieldMapping = fieldLookup["Out_Entry4"];
            //    obj.Out_Entry4 = CreateMetaValues(fieldMapping);
            //}

            //{
            //    // Initialize meta value structure to "Out_Entry5" field
            //    FieldMapping fieldMapping = fieldLookup["Out_Entry5"];
            //    obj.Out_Entry5 = CreateMetaValues(fieldMapping);
            //}

            //{
            //    // Initialize meta value structure to "Out_Entry6" field
            //    FieldMapping fieldMapping = fieldLookup["Out_Entry6"];
            //    obj.Out_Entry6 = CreateMetaValues(fieldMapping);
            //}

            //{
            //    // Initialize meta value structure to "Out_Entry7" field
            //    FieldMapping fieldMapping = fieldLookup["Out_Entry7"];
            //    obj.Out_Entry7 = CreateMetaValues(fieldMapping);
            //}

            //{
            //    // Initialize meta value structure to "Out_Entry8" field
            //    FieldMapping fieldMapping = fieldLookup["Out_Entry8"];
            //    obj.Out_Entry8 = CreateMetaValues(fieldMapping);
            //}

            //{
            //    // Initialize meta value structure to "Out_Entry9" field
            //    FieldMapping fieldMapping = fieldLookup["Out_Entry9"];
            //    obj.Out_Entry9 = CreateMetaValues(fieldMapping);
            //}

            //{
            //    // Initialize meta value structure to "Out_Entry10" field
            //    FieldMapping fieldMapping = fieldLookup["Out_Entry10"];
            //    obj.Out_Entry10 = CreateMetaValues(fieldMapping);
            //}

            //{
            //    // Initialize meta value structure to "Out_Entry11" field
            //    FieldMapping fieldMapping = fieldLookup["Out_Entry11"];
            //    obj.Out_Entry11 = CreateMetaValues(fieldMapping);
            //}

            return obj;
        }

        private void CollectFromGPAOut_Data(List<IMeasurement> measurements, TypeMapping typeMapping, SSDQopenECA.Model.GPA.Out_Data data, SSDQopenECA.Model.GPA._Out_DataMeta meta)
        {
            Dictionary<string, FieldMapping> fieldLookup = typeMapping.FieldMappings.ToDictionary(mapping => mapping.Field.Identifier);

            if (FrameworkConfiguration.newframework)
            {
                int count = Algorithm.New_config.Outentrynamelist.Count();
                for (int i = 0; i < count; i++)
                {
                    // Convert value from "Out_Entry1" field to measurement
                    FieldMapping fieldMapping = fieldLookup[Algorithm.New_config.Outentrynamelist[i]];
                    //PropertyInfo temp = meta.GetType().GetProperty(Input_screen.Outentrynamelist[i]);
                    IMeasurement measurement = MakeMeasurement((MetaValues)meta.GetType().GetProperty(Algorithm.New_config.Outentrynamelist[i]).GetValue(meta, null), (double)data.GetType().GetProperty(Algorithm.New_config.Outentrynamelist[i]).GetValue(data, null));
                    measurements.Add(measurement);


                    //FieldMapping fieldMapping = fieldLookup[Input_screen.Outentrynamelist[i]];
                    //IMeasurement measurement = MakeMeasurement(meta.Out_Entry1, (double)data.Out_Entry1);
                    //measurements.Add(measurement);

                }
            }
            else
            {
                int count = Algorithm.Stored_config.Outentrynamelist.Count();
                for (int i = 0; i < count; i++)
                {
                    // Convert value from "Out_Entry1" field to measurement
                    FieldMapping fieldMapping = fieldLookup[Algorithm.Stored_config.Outentrynamelist[i]];
                    //PropertyInfo temp = meta.GetType().GetProperty(Input_screen.Outentrynamelist[i]);
                    IMeasurement measurement = MakeMeasurement((MetaValues)meta.GetType().GetProperty(Algorithm.Stored_config.Outentrynamelist[i]).GetValue(meta, null), (double)data.GetType().GetProperty(Algorithm.Stored_config.Outentrynamelist[i]).GetValue(data, null));
                    measurements.Add(measurement);


                    //FieldMapping fieldMapping = fieldLookup[Input_screen.Outentrynamelist[i]];
                    //IMeasurement measurement = MakeMeasurement(meta.Out_Entry1, (double)data.Out_Entry1);
                    //measurements.Add(measurement);

                }
            }
            
            //{
            //    // Convert value from "Out_Entry1" field to measurement
            //    FieldMapping fieldMapping = fieldLookup["Out_Entry1"];
            //    IMeasurement measurement = MakeMeasurement(meta.Out_Entry1, (double)data.Out_Entry1);
            //    measurements.Add(measurement);
            //}

            //{
            //    // Convert value from "Out_Entry2" field to measurement
            //    FieldMapping fieldMapping = fieldLookup["Out_Entry2"];
            //    IMeasurement measurement = MakeMeasurement(meta.Out_Entry2, (double)data.Out_Entry2);
            //    measurements.Add(measurement);
            //}

            //{
            //    // Convert value from "Out_Entry3" field to measurement
            //    FieldMapping fieldMapping = fieldLookup["Out_Entry3"];
            //    IMeasurement measurement = MakeMeasurement(meta.Out_Entry3, (double)data.Out_Entry3);
            //    measurements.Add(measurement);
            //}

            //{
            //    // Convert value from "Out_Entry4" field to measurement
            //    FieldMapping fieldMapping = fieldLookup["Out_Entry4"];
            //    IMeasurement measurement = MakeMeasurement(meta.Out_Entry4, (double)data.Out_Entry4);
            //    measurements.Add(measurement);
            //}

            //{
            //    // Convert value from "Out_Entry5" field to measurement
            //    FieldMapping fieldMapping = fieldLookup["Out_Entry5"];
            //    IMeasurement measurement = MakeMeasurement(meta.Out_Entry5, (double)data.Out_Entry5);
            //    measurements.Add(measurement);
            //}

            //{
            //    // Convert value from "Out_Entry6" field to measurement
            //    FieldMapping fieldMapping = fieldLookup["Out_Entry6"];
            //    IMeasurement measurement = MakeMeasurement(meta.Out_Entry6, (double)data.Out_Entry6);
            //    measurements.Add(measurement);
            //}

            //{
            //    // Convert value from "Out_Entry7" field to measurement
            //    FieldMapping fieldMapping = fieldLookup["Out_Entry7"];
            //    IMeasurement measurement = MakeMeasurement(meta.Out_Entry7, (double)data.Out_Entry7);
            //    measurements.Add(measurement);
            //}

            //{
            //    // Convert value from "Out_Entry8" field to measurement
            //    FieldMapping fieldMapping = fieldLookup["Out_Entry8"];
            //    IMeasurement measurement = MakeMeasurement(meta.Out_Entry8, (double)data.Out_Entry8);
            //    measurements.Add(measurement);
            //}

            //{
            //    // Convert value from "Out_Entry9" field to measurement
            //    FieldMapping fieldMapping = fieldLookup["Out_Entry9"];
            //    IMeasurement measurement = MakeMeasurement(meta.Out_Entry9, (double)data.Out_Entry9);
            //    measurements.Add(measurement);
            //}

            //{
            //    // Convert value from "Out_Entry10" field to measurement
            //    FieldMapping fieldMapping = fieldLookup["Out_Entry10"];
            //    IMeasurement measurement = MakeMeasurement(meta.Out_Entry10, (double)data.Out_Entry10);
            //    measurements.Add(measurement);
            //}

            //{
            //    // Convert value from "Out_Entry11" field to measurement
            //    FieldMapping fieldMapping = fieldLookup["Out_Entry11"];
            //    IMeasurement measurement = MakeMeasurement(meta.Out_Entry11, (double)data.Out_Entry11);
            //    measurements.Add(measurement);
            //}
        }

        #endregion
    }
}
