// COMPILER GENERATED CODE
// THIS WILL BE OVERWRITTEN AT EACH GENERATION
// EDIT AT YOUR OWN RISK

using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ECAClientFramework;
using ECAClientUtilities;
using ECACommonUtilities;
using ECACommonUtilities.Model;
using GSF.TimeSeries;

namespace SSDQopenECA.Model
{
    [CompilerGenerated]
    public class Mapper : MapperBase
    {
        #region [ Members ]

        // Fields
        private readonly Unmapper m_unmapper;

        #endregion

        #region [ Constructors ]

        public Mapper(Framework framework)
            : base(framework, SystemSettings.InputMapping)
        {
            m_unmapper = new Unmapper(framework, MappingCompiler);
            Unmapper = m_unmapper;
        }

        #endregion

        #region [ Methods ]

        public override void Map(IDictionary<MeasurementKey, IMeasurement> measurements)
        {
            SignalLookup.UpdateMeasurementLookup(measurements);
            TypeMapping inputMapping = MappingCompiler.GetTypeMapping(InputMapping);

            Reset();
            SSDQopenECA.Model.GPA.In_Data inputData = CreateGPAIn_Data(inputMapping);
            Reset();
            SSDQopenECA.Model.GPA._In_DataMeta inputMeta = CreateGPA_In_DataMeta(inputMapping);

            Algorithm.Output algorithmOutput = Algorithm.Execute(inputData, inputMeta);
            Subscriber.SendMeasurements(m_unmapper.Unmap(algorithmOutput.OutputData, algorithmOutput.OutputMeta));
        }

        private SSDQopenECA.Model.GPA.In_Data CreateGPAIn_Data(TypeMapping typeMapping)
        {
            Dictionary<string, FieldMapping> fieldLookup = typeMapping.FieldMappings.ToDictionary(mapping => mapping.Field.Identifier);
            SSDQopenECA.Model.GPA.In_Data obj = new SSDQopenECA.Model.GPA.In_Data();

            {
                // Assign double value to "In_Entry1" field
                FieldMapping fieldMapping = fieldLookup["In_Entry1"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.In_Entry1 = (double)measurement.Value;
            }

            {
                // Assign double value to "In_Entry2" field
                FieldMapping fieldMapping = fieldLookup["In_Entry2"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.In_Entry2 = (double)measurement.Value;
            }

            {
                // Assign double value to "In_Entry3" field
                FieldMapping fieldMapping = fieldLookup["In_Entry3"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.In_Entry3 = (double)measurement.Value;
            }

            {
                // Assign double value to "In_Entry4" field
                FieldMapping fieldMapping = fieldLookup["In_Entry4"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.In_Entry4 = (double)measurement.Value;
            }

            {
                // Assign double value to "In_Entry5" field
                FieldMapping fieldMapping = fieldLookup["In_Entry5"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.In_Entry5 = (double)measurement.Value;
            }

            {
                // Assign double value to "In_Entry6" field
                FieldMapping fieldMapping = fieldLookup["In_Entry6"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.In_Entry6 = (double)measurement.Value;
            }

            {
                // Assign double value to "In_Entry7" field
                FieldMapping fieldMapping = fieldLookup["In_Entry7"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.In_Entry7 = (double)measurement.Value;
            }

            {
                // Assign double value to "In_Entry8" field
                FieldMapping fieldMapping = fieldLookup["In_Entry8"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.In_Entry8 = (double)measurement.Value;
            }

            {
                // Assign double value to "In_Entry9" field
                FieldMapping fieldMapping = fieldLookup["In_Entry9"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.In_Entry9 = (double)measurement.Value;
            }

            {
                // Assign double value to "In_Entry10" field
                FieldMapping fieldMapping = fieldLookup["In_Entry10"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.In_Entry10 = (double)measurement.Value;
            }

            {
                // Assign double value to "In_Entry11" field
                FieldMapping fieldMapping = fieldLookup["In_Entry11"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.In_Entry11 = (double)measurement.Value;
            }

            return obj;
        }

        private SSDQopenECA.Model.GPA._In_DataMeta CreateGPA_In_DataMeta(TypeMapping typeMapping)
        {
            Dictionary<string, FieldMapping> fieldLookup = typeMapping.FieldMappings.ToDictionary(mapping => mapping.Field.Identifier);
            SSDQopenECA.Model.GPA._In_DataMeta obj = new SSDQopenECA.Model.GPA._In_DataMeta();

            {
                // Assign MetaValues value to "In_Entry1" field
                FieldMapping fieldMapping = fieldLookup["In_Entry1"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.In_Entry1 = GetMetaValues(measurement);
            }

            {
                // Assign MetaValues value to "In_Entry2" field
                FieldMapping fieldMapping = fieldLookup["In_Entry2"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.In_Entry2 = GetMetaValues(measurement);
            }

            {
                // Assign MetaValues value to "In_Entry3" field
                FieldMapping fieldMapping = fieldLookup["In_Entry3"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.In_Entry3 = GetMetaValues(measurement);
            }

            {
                // Assign MetaValues value to "In_Entry4" field
                FieldMapping fieldMapping = fieldLookup["In_Entry4"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.In_Entry4 = GetMetaValues(measurement);
            }

            {
                // Assign MetaValues value to "In_Entry5" field
                FieldMapping fieldMapping = fieldLookup["In_Entry5"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.In_Entry5 = GetMetaValues(measurement);
            }

            {
                // Assign MetaValues value to "In_Entry6" field
                FieldMapping fieldMapping = fieldLookup["In_Entry6"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.In_Entry6 = GetMetaValues(measurement);
            }

            {
                // Assign MetaValues value to "In_Entry7" field
                FieldMapping fieldMapping = fieldLookup["In_Entry7"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.In_Entry7 = GetMetaValues(measurement);
            }

            {
                // Assign MetaValues value to "In_Entry8" field
                FieldMapping fieldMapping = fieldLookup["In_Entry8"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.In_Entry8 = GetMetaValues(measurement);
            }

            {
                // Assign MetaValues value to "In_Entry9" field
                FieldMapping fieldMapping = fieldLookup["In_Entry9"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.In_Entry9 = GetMetaValues(measurement);
            }

            {
                // Assign MetaValues value to "In_Entry10" field
                FieldMapping fieldMapping = fieldLookup["In_Entry10"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.In_Entry10 = GetMetaValues(measurement);
            }

            {
                // Assign MetaValues value to "In_Entry11" field
                FieldMapping fieldMapping = fieldLookup["In_Entry11"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.In_Entry11 = GetMetaValues(measurement);
            }

            return obj;
        }

        #endregion
    }
}
