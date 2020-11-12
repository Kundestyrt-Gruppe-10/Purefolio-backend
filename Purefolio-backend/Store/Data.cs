using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using Purefolio.DatabaseContext;
using Purefolio_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Purefolio_backend
{
    public class BaseData

    {
        protected List<Nace> naces = new List<Nace>() {
                new Nace() {  naceCode = "A", naceName = "Agriculture, forestry and fishing" },
                new Nace() {  naceCode = "A01", naceName = "Crop and animal production, hunting and related service activities" },
                new Nace() {  naceCode = "A02", naceName = "Forestry and logging" },
                new Nace() {  naceCode = "A03", naceName = "Fishing and aquaculture" },
                new Nace() {  naceCode = "B", naceName = "Mining and quarrying" },
                new Nace() {  naceCode = "B05", naceName = "Mining of coal and lignite" },
                new Nace() {  naceCode = "B06", naceName = "Extraction of crude petroleum and natural gas" },
                new Nace() {  naceCode = "B07", naceName = "Mining of metal ores" },
                new Nace() {  naceCode = "B08", naceName = "Other mining and quarrying" },
                new Nace() {  naceCode = "B09", naceName = "Mining support service activities" },
                new Nace() {  naceCode = "C", naceName = "Manufacturing" },
                new Nace() {  naceCode = "C10", naceName = "Manufacture of food products" },
                new Nace() {  naceCode = "C11", naceName = "Manufacture of beverages" },
                new Nace() {  naceCode = "C12", naceName = "Manufacture of tobacco products" },
                new Nace() {  naceCode = "C13", naceName = "Manufacture of textiles" },
                new Nace() {  naceCode = "C14", naceName = "Manufacture of wearing apparel" },
                new Nace() {  naceCode = "C15", naceName = "Manufacture of leather and related products" },
                new Nace() {  naceCode = "C16", naceName = "Manufacture of wood and of products of wood and cork, except furniture; manufacture of articles of straw and plaiting materials" },
                new Nace() {  naceCode = "C17", naceName = "Manufacture of paper and paper product" },
                new Nace() {  naceCode = "C18", naceName = "Printing and reproduction of recorded media" },
                new Nace() {  naceCode = "C19", naceName = "Manufacture of coke and refined petroleum products" },
                new Nace() {  naceCode = "C20", naceName = "Manufacture of chemicals and chemical products" },
                new Nace() {  naceCode = "C21", naceName = "Manufacture of basic pharmaceutical products and pharmaceutical preparations" },
                new Nace() {  naceCode = "C22", naceName = "Manufacture of rubber and plastic products" },
                new Nace() {  naceCode = "C23", naceName = "Manufacture of other non-metallic mineral products" },
                new Nace() {  naceCode = "C24", naceName = "Manufacture of basic metals" },
                new Nace() {  naceCode = "C25", naceName = "Manufacture of fabricated metal products, except machinery and equipment" },
                new Nace() {  naceCode = "C26", naceName = "Manufacture of computer, electronic and optical products" },
                new Nace() {  naceCode = "C27", naceName = "Manufacture of electrical equipment" },
                new Nace() {  naceCode = "C28", naceName = "Manufacture of machinery and equipment n.e.c." },
                new Nace() {  naceCode = "C29", naceName = "Manufacture of motor vehicles, trailers and semi-trailers" },
                new Nace() {  naceCode = "C30", naceName = "Manufacture of other transport equipment" },
                new Nace() {  naceCode = "C31", naceName = "Manufacture of furniture" },
                new Nace() {  naceCode = "C32", naceName = "Other manufacturing" },
                new Nace() {  naceCode = "C33", naceName = "Repair and installation of machinery and equipment" },
                new Nace() {  naceCode = "D", naceName = "Electricity, gas, steam and air conditioning supply" },
                new Nace() {  naceCode = "E", naceName = "Water supply; sewerage, waste management and remediation activities" },
                new Nace() {  naceCode = "E36", naceName = "Water collection, treatment and supply" },
                new Nace() {  naceCode = "E37", naceName = "Sewerage" },
                new Nace() {  naceCode = "E38", naceName = "Waste collection, treatment and disposal activities; materials recovery" },
                new Nace() {  naceCode = "E39", naceName = "Remediation activities and other waste management services" },
                new Nace() {  naceCode = "F", naceName = "Construction" },
                new Nace() {  naceCode = "F41", naceName = "Construction of buildings" },
                new Nace() {  naceCode = "F42", naceName = "Civil engineering" },
                new Nace() {  naceCode = "F43", naceName = "Specialised construction activities" },
                new Nace() {  naceCode = "G", naceName = "Wholesale and retail trade; repair of motor vehicles and motorcycles"  },
                new Nace() {  naceCode = "G45", naceName = "Wholesale and retail trade and repair of motor vehicles and motorcycles"  },
                new Nace() {  naceCode = "G46", naceName = "Wholesale trade, except of motor vehicles and motorcycles"  },
                new Nace() {  naceCode = "G47", naceName = "Retail trade, except of motor vehicles and motorcycles"  },
                new Nace() {  naceCode = "H", naceName = "Transportation and storage" },
                new Nace() {  naceCode = "H49", naceName = "Land transport and transport via pipelines" },
                new Nace() {  naceCode = "H50", naceName = "Water transport" },
                new Nace() {  naceCode = "H51", naceName = "Air transport" },
                new Nace() {  naceCode = "H52", naceName = "Warehousing and support activities for transportation" },
                new Nace() {  naceCode = "H53", naceName = "Postal and courier activities" },
                new Nace() {  naceCode = "I", naceName = "Accommodation and food service activities" },
                new Nace() {  naceCode = "I55", naceName = "Accommodation" },
                new Nace() {  naceCode = "I56", naceName = "Food and beverage service activities" },
                new Nace() {  naceCode = "J", naceName = "Information and communication" },
                new Nace() {  naceCode = "J58", naceName = "Publishing activities" },
                new Nace() {  naceCode = "J59", naceName = "Motion picture, video and television programme production, sound recording and music publishing activities" },
                new Nace() {  naceCode = "J60", naceName = "Programming and broadcasting activities" },
                new Nace() {  naceCode = "J61", naceName = "Telecommunications" },
                new Nace() {  naceCode = "J62", naceName = "Computer programming, consultancy and related activities " },
                new Nace() {  naceCode = "J63", naceName = "Information service activities" },
                new Nace() {  naceCode = "K", naceName = "Financial and insurance activities" },
                new Nace() {  naceCode = "K64", naceName = "Financial service activities, except insurance and pension funding" },
                new Nace() {  naceCode = "K65", naceName = "Insurance, reinsurance and pension funding, except compulsory social security" },
                new Nace() {  naceCode = "K66", naceName = "Activities auxiliary to financial services and insurance activities" },
                new Nace() {  naceCode = "L", naceName = "Real estate activities" },
                new Nace() {  naceCode = "M", naceName = "Professional, scientific and technical activities" },
                new Nace() {  naceCode = "M69", naceName = "Legal and accounting activities" },
                new Nace() {  naceCode = "M70", naceName = "Activities of head offices; management consultancy activities" },
                new Nace() {  naceCode = "M71", naceName = "Architectural and engineering activities; technical testing and analysis" },
                new Nace() {  naceCode = "M72", naceName = "Scientific research and development" },
                new Nace() {  naceCode = "M73", naceName = "Advertising and market research" },
                new Nace() {  naceCode = "M74", naceName = "Other professional, scientific and technical activities" },
                new Nace() {  naceCode = "M75", naceName = "Veterinary activities" },
                new Nace() {  naceCode = "N", naceName = "Administrative and support service activities" },
                new Nace() {  naceCode = "N77", naceName = "Rental and leasing activities" },
                new Nace() {  naceCode = "N78", naceName = "Employment activities" },
                new Nace() {  naceCode = "N79", naceName = "Travel agency, tour operator and other reservation service and related activities" },
                new Nace() {  naceCode = "N80", naceName = "Security and investigation activities" },
                new Nace() {  naceCode = "N81", naceName = "Services to buildings and landscape activities" },
                new Nace() {  naceCode = "N82", naceName = "Office administrative, office support and other business support activities" },
                new Nace() {  naceCode = "O", naceName = "Public administration and defence; compulsory social security" },
                new Nace() {  naceCode = "P", naceName = "Education" },
                new Nace() {  naceCode = "Q", naceName = "Human health and social work activities" },
                new Nace() {  naceCode = "Q86", naceName = "Human health activities" },
                new Nace() {  naceCode = "Q87", naceName = "Residential care activities" },
                new Nace() {  naceCode = "Q88", naceName = "Social work activities without accommodation" },
                new Nace() {  naceCode = "R", naceName = "Arts, entertainment and recreation" },
                new Nace() {  naceCode = "R90", naceName = "Creative, arts and entertainment activities" },
                new Nace() {  naceCode = "R91", naceName = "Libraries, archives, museums and other cultural activities" },
                new Nace() {  naceCode = "R92", naceName = "Gambling and betting activities" },
                new Nace() {  naceCode = "R93", naceName = "Sports activities and amusement and recreation activities" },
                new Nace() {  naceCode = "S", naceName = "Other service activities" },
                new Nace() {  naceCode = "S94", naceName = "Activities of membership organisations" },
                new Nace() {  naceCode = "S95", naceName = "Repair of computers and personal and household goods" },
                new Nace() {  naceCode = "S96", naceName = "Other personal service activities" },
                new Nace() {  naceCode = "T", naceName = "Activities of household as employers; undifferentiated goods- and services-producing activities of households for own account" },
                new Nace() {  naceCode = "T97", naceName = "Activities of households as employers of domestic personnel" },
                new Nace() {  naceCode = "T98", naceName = "Undifferentiated goods- and services-producing activities of private households for own use" },
                new Nace() {  naceCode = "U", naceName = "Activities of extraterritorial organisations and bodies" },
                new Nace() {  naceCode = "TOTAL", naceName = "Total - All NACE activities" },
            };
        
        protected List<Region> regions = new List<Region>() 
            { 
                new Region() { regionCode = "AT", regionName = "Austria", area = 83858 },
                new Region() { regionCode = "BE", regionName = "Belgium", area = 30510 },
                new Region() { regionCode = "BG", regionName = "Bulgaria", area = 110994 },
                new Region() { regionCode = "CH", regionName = "Switzerland", area = 41290 },
                new Region() { regionCode = "CY", regionName = "Cyprus", area = 9251 },
                new Region() { regionCode = "CZ", regionName = "Czechia", area = 78866},
                new Region() { regionCode = "DE", regionName = "Germany", area = 357386},
                new Region() { regionCode = "DK", regionName = "Denmark", area = 44493 },
                new Region() { regionCode = "EE", regionName = "Estonia", area = 45339 },
                new Region() { regionCode = "EL", regionName = "Greece", area = 131940},
                new Region() { regionCode = "ES", regionName = "Spain", area = 498511 },
                new Region() { regionCode = "EU27_2020", regionName = "European Union - 27 countries (from 2020)"},
                new Region() { regionCode = "FI", regionName = "Finland", area = 338145 },
                new Region() { regionCode = "FR", regionName = "France", area = 551695 },
                new Region() { regionCode = "HR", regionName = "Croatia", area = 56594 },
                new Region() { regionCode = "HU", regionName = "Hungary", area = 93030 },
                new Region() { regionCode = "IE", regionName = "Ireland", area = 70273 },
                new Region() { regionCode = "IS", regionName = "Iceland", area = 102775 },
                new Region() { regionCode = "IT", regionName = "Italy", area = 301338 },
                new Region() { regionCode = "LT", regionName = "Lithuania", area = 65300 },
                new Region() { regionCode = "LU", regionName = "Luxembourg" , area = 2586 },
                new Region() { regionCode = "LV", regionName = "Latvia", area = 64589 },
                new Region() { regionCode = "MT", regionName = "Malta", area = 316 },
                new Region() { regionCode = "NL", regionName = "Netherlands", area = 41198 },
                new Region() { regionCode = "NO", regionName = "Norway", area = 385178 },
                new Region() { regionCode = "PL", regionName = "Poland", area = 312685 },
                new Region() { regionCode = "PT", regionName = "Portugal", area = 91568 },
                new Region() { regionCode = "RO", regionName = "Romania", area = 238397 },
                new Region() { regionCode = "RS", regionName = "Serbia", area = 77453 },
                new Region() { regionCode = "SE", regionName = "Sweden", area = 450295 },
                new Region() { regionCode = "SI", regionName = "Slovenia", area = 20273 },
                new Region() { regionCode = "SK", regionName = "Slovakia", area = 49036 },
                new Region() { regionCode = "TR", regionName = "Turkey", area = 783562 },
                new Region() { regionCode = "UK", regionName = "United Kingdom", area = 242495 },
            };  

/// Environment
/// Corporate Governance
/// Social
        
        protected List<EuroStatTable> euroStatTables = new List<EuroStatTable>()
        {
            new EuroStatTable(){tableCode = "env_ac_aeint_r2", attributeName = "emissionPerYear", dataType="NaceRegionData", filters="airpol=GHG&na_item=B1G&unit=G_EUR_CP", unit="Gram per Euro", datasetName="Emmisions of Greenhouse gases", esgFactor="Environment", description="Air Emissions Accounts record the flows of residual gaseous and particulate materials emitted by resident units and flowing into the atmosphere. Residual gaseous and particulate materials are the physical flows of gaseous or particulate materials (‘air emissions’).", href="https://ec.europa.eu/eurostat/cache/metadata/en/env_ac_ainah_r2_esms.htm"},
            new EuroStatTable(){tableCode = "hsw_n2_03", attributeName = "workAccidentsIncidentRate", dataType="NaceRegionData", filters="unit=RT_INC&age=TOTAL", unit="Incidence rate", datasetName="Non-fatal accidents at work", esgFactor="Social", description="An accident at work is defined as 'a discrete occurrence in the course of work which leads to physical or mental harm'. The data include non-fatal accidents involving more than 3 calendar days of absence from work. If the accident does not lead to the death of the victim it is called a 'non-fatal' (or 'serious') accident.", href="https://ec.europa.eu/eurostat/cache/metadata/en/hsw_acc_work_esms.htm"},
            new EuroStatTable(){tableCode = "earn_gr_gpgr2", attributeName = "genderPayGap", dataType="NaceRegionData", filters="unit=PC", unit="Percentage", datasetName="Gender pay gap", esgFactor="Social", description="The unadjusted gender pay gap (GPG) represents the difference between average gross hourly earnings of male paid employees and of female paid employees as a percentage of average gross hourly earnings of male paid employees.", href="https://ec.europa.eu/eurostat/cache/metadata/en/earn_grgpg2_esms.htm"},
            new EuroStatTable(){tableCode = "env_ac_taxind2", attributeName = "environmentTaxes", dataType="NaceRegionData", filters="tax=ENV&unit=MIO_EUR", unit="Million Euros", datasetName="Environmental taxes by economic activity", esgFactor="Environment", description="The environmental tax statistics are based on Eurostat’s 2013 'Environmental taxes - a statistical guide'. Environmental tax statistics are part of the environmental accounts which constitute satellite accounts to national accounts.", href="https://ec.europa.eu/eurostat/cache/metadata/en/env_ac_taxind2_esms.htm"},
            new EuroStatTable(){tableCode = "hsw_n2_02", attributeName = "fatalAccidentsAtWork", dataType="NaceRegionData", filters="unit=RT_INC", unit="Incidence rate", datasetName="Fatal Accidents at work", esgFactor="Social", description="An accident at work is defined as 'a discrete occurrence in the course of work which leads to physical or mental harm'. A fatal accident at work is defined as an accident which leads to the death of a victim within one year of the accident.", href="https://ec.europa.eu/eurostat/cache/metadata/en/hsw_acc_work_esms.htm"},
            new EuroStatTable(){tableCode = "lfsa_etgan2", attributeName = "temporaryemployment", dataType="NaceRegionData", filters="sex=T&unit=THS&age=Y15-74", unit="Thousand", datasetName="Temporary employees", esgFactor="Social", description="Temporary employment.", href="https://ec.europa.eu/eurostat/cache/metadata/en/lfsa_esms.htm"},
            new EuroStatTable(){tableCode = "edat_lfs_9910", attributeName = "employeesPrimaryEducation", dataType="NaceRegionData", filters="sex=T&unit=PC&isced11=ED0-2&age=Y15-74", unit="Percentage", datasetName="Employees with less than secondary education", esgFactor="Corporate Governance", description="Less than primary, primary and lower secondary education: this aggregate refers to levels 0, 1 and 2 of the ISCED 2011 (online code ED0-2). Data up to 2013 refer to ISCED 1997 levels 0, 1 and 2 but also include level 3C short (educational attainment from ISCED level 3 programmes of less than two years).", href="https://ec.europa.eu/eurostat/cache/metadata/en/edat1_esms.htm"},
            new EuroStatTable(){tableCode = "edat_lfs_9910", attributeName = "employeesSecondaryEducation", dataType="NaceRegionData", filters="sex=T&unit=PC&isced11=ED3_4&age=Y15-74", unit="Percentage", datasetName="Employees with secondary education", esgFactor="Corporate Governance", description="Upper secondary and post-secondary non-tertiary education: this aggregate corresponds to ISCED 2011 levels 3 and 4 (online code ED3_4). ISCED 2011 level 3 programmes of partial level completion are considered within ISCED level 3", href="https://ec.europa.eu/eurostat/cache/metadata/en/edat1_esms.htm"},
            new EuroStatTable(){tableCode = "edat_lfs_9910", attributeName = "employeesTertiaryEducation", dataType="NaceRegionData", filters="sex=T&unit=PC&isced11=ED5-8&age=Y15-74", unit="Percentage", datasetName="Employees with tertiary education", esgFactor="Corporate Governance", description="Tertiary education: this aggregate covers ISCED 2011 levels 5, 6, 7 and 8 (short-cycle tertiary education, bachelor's or equivalent level, master's or equivalent level, doctoral or equivalent level, online code ED5-8 ‘tertiary education’).", href="https://ec.europa.eu/eurostat/cache/metadata/en/edat1_esms.htm"},
            new EuroStatTable(){tableCode = "earn_ses_pub1n", attributeName = "employeesLowWage", dataType="NaceRegionData", filters="unit=PC&sizeclas=GE10", unit="Percentage", datasetName="Low-wage earners as a proportion of all employees", esgFactor="Social", description="Low-wage earners are defined as those employees (excluding apprentices) earning two-thirds or less of the national median gross hourly earnings in that particular country.", href="https://ec.europa.eu/eurostat/cache/metadata/en/earn_ses_main_esms.htm"},
            new EuroStatTable(){tableCode = "lc_nhour_r2", attributeName = "hoursPaidAndNot", dataType="NaceRegionData", filters="indic_lc=HP_HW_RAT&sizeclas=GE10", unit="Ratio", datasetName="Hours worked compared to hours paid", esgFactor="Social", description="Ratio between hours paid and actual work.", href="https://ec.europa.eu/eurostat/cache/metadata/en/lcs_r2_esms.htm"},
            new EuroStatTable(){tableCode = "lfsa_ewhan2", attributeName = "hoursWorkWeek", dataType="NaceRegionData", filters="sex=T&unit=HR&wstatus=EMP&worktime=FT", unit="Hours", datasetName="Average number of actual weekly hours of work", esgFactor="Social", description="Average number of actual weekly hours of work for full-time employed workers.", href="https://ec.europa.eu/eurostat/cache/metadata/en/lcs_r2_esms.htm"},
            new EuroStatTable(){tableCode = "jvs_a_rate_r2", attributeName = "jobVacancyRate", dataType="NaceRegionData", filters="unit=AVG_A&sizeclas=TOTAL", unit="Annual average", datasetName="Job vacancy rate", esgFactor="Social", description="The job vacancy rate (JVR) is the number of job vacancies expresses as a percentage of the sum of the number of occupied posts and the number of job vacancies. A 'job vacancy' is defined as a paid post that is newly created, unoccupied, or about to become vacant:(a) for which the employer is taking active steps and is prepared to take further steps to find a suitable candidate from outside the enterprise concerned and (b) which the employer intends to fill either immediately or within a specific period of time.", href="https://ec.europa.eu/eurostat/cache/metadata/en/jvs_esms.htm"},
            new EuroStatTable(){tableCode = "trng_lfs_08b", attributeName = "trainingParticipation", dataType="NaceRegionData", filters="sex=T&unit=PC&age=Y18-74", unit="Percentage", datasetName="Participation rate in education and training", esgFactor="Corporate Governance", description="The participation rate in education and training covers participation in formal and non-formal education and training. The reference period for the participation in education and training is the four weeks prior to the interview.", href="https://ec.europa.eu/eurostat/cache/metadata/en/trng_lfs_4w0_esms.htm"},
            new EuroStatTable(){tableCode = "env_wasgen", attributeName = "totalWaste", dataType="NaceRegionData", filters="waste=TOTAL&unit=KG_HAB&hazard=HAZ_NHAZ", unit="Kilograms per capita", datasetName="Generation of waste", esgFactor="Environment", description="The generation of waste is attributed to either production or consumption activities. For production activities a further breakdown is supplied in 18 economic activities according to the NACE rev. 2 classification.", href="https://ec.europa.eu/eurostat/cache/metadata/en/env_wasgt_esms.htm"},
            new EuroStatTable(){tableCode = "env_wasgen", attributeName = "totalHazardousWaste", dataType="NaceRegionData", filters="waste=TOTAL&unit=KG_HAB&hazard=HAZ", unit="Kilograms per capita", datasetName="Generation of hazardous waste", esgFactor="Environment", description="The generation of waste is attributed to either production or consumption activities. For production activities a further breakdown is supplied in 18 economic activities according to the NACE rev. 2 classification.", href="https://ec.europa.eu/eurostat/cache/metadata/en/env_wasgt_esms.htm"},
            new EuroStatTable(){tableCode = "env_wasgen", attributeName = "totalNonHazardousWaste", dataType="NaceRegionData", filters="waste=TOTAL&unit=KG_HAB&hazard=NHAZ", unit="Kilograms per capita", datasetName="Generation of non-hazardous waste", esgFactor="Environment", description="The generation of waste is attributed to either production or consumption activities. For production activities a further breakdown is supplied in 18 economic activities according to the NACE rev. 2 classification.", href="https://ec.europa.eu/eurostat/cache/metadata/en/env_wasgt_esms.htm"},
            new EuroStatTable(){tableCode = "sbs_env_dom_r2", attributeName = "environmentalProtectionPollution", dataType="NaceRegionData", filters="ceparema=TOT_CEPA&indic_sb=V21110", unit="Million Euros", datasetName="Environmental protection expenditure - Pollution control", esgFactor="Environment", description="Investment in equipment and plant for pollution control and special anti-pollution accessories (mainly 'end-of-pipe' equipment.)", href="https://ec.europa.eu/eurostat/cache/metadata/en/sbs_env_esms.htm"},
            new EuroStatTable(){tableCode = "sbs_env_dom_r2", attributeName = "environmentalProtectionTech", dataType="NaceRegionData", filters="ceparema=TOT_CEPA&indic_sb=V21120", unit="Million Euros", datasetName="Environmental protection expenditure - Cleaner technology", esgFactor="Environment", description="Investment in equipment and plant linked to cleaner technologies ('integrated technology')", href="https://ec.europa.eu/eurostat/cache/metadata/en/sbs_env_esms.htm"},
            new EuroStatTable(){tableCode = "migr_ressw1_1", attributeName = "seasonalWork", dataType="NaceRegionData", filters="citizen=TOTAL&decision=GRANTED&duration=TOTAL&unit=NR", unit="Number", datasetName="Authorisations for the purpose of seasonal work", esgFactor="Social", description="Authorisations for the purpose of seasonal work. This counts the number of permits/authorisations/notifications issued for the purpose of the directives allowing double counting of same persons during the year.", href="https://ec.europa.eu/eurostat/cache/metadata/en/migr_res_esms.htm"},
            new EuroStatTable(){tableCode = "env_ac_pefasu", attributeName = "supplyEnergyProducts", dataType="NaceRegionData", filters="unit=TJ&stk_flow=SUP&prod_nrg=P00", unit="Terajoule", datasetName="Energy supply - Energy products", esgFactor="Environment", description="Energy products: output flows from production processes as defined in national accounts (ESA); typically products produced by extractive industries, refineries, power plants etc.", href="https://ec.europa.eu/eurostat/cache/metadata/en/env_pefa_esms.htm"},
            new EuroStatTable(){tableCode = "env_ac_pefasu", attributeName = "supplyEnergyResiduals", dataType="NaceRegionData", filters="unit=TJ&stk_flow=SUP&prod_nrg=R00", unit="Terajoule", datasetName="Energy supply - Energy residuals", esgFactor="Environment", description="Energy residuals: mainly energy in form of dissipative heat arising from the end use of energy products, flowing from the economy into the natural environment.", href="https://ec.europa.eu/eurostat/cache/metadata/en/env_pefa_esms.htm"},
            new EuroStatTable(){tableCode = "env_ac_pefasu", attributeName = "useNaturalEnergyInputs", dataType="NaceRegionData", filters="unit=TJ&stk_flow=USE&prod_nrg=N00", unit="Terajoule", datasetName="Energy use - Natural energy inputs", esgFactor="Environment", description="Natural energy inputs: flows from the natural environment into the econmy such as fossil energy carriers in solid, liquid and gaseous form, biomass, solar radiation, kinetic energy in form of hydro and wind, geothermal heat etc", href="https://ec.europa.eu/eurostat/cache/metadata/en/env_pefa_esms.htm"},
            new EuroStatTable(){tableCode = "env_ac_pefasu", attributeName = "useEnergyProducts", dataType="NaceRegionData", filters="unit=TJ&stk_flow=USE&prod_nrg=P00", unit="Terajoule", datasetName="Energy use - Energy products", esgFactor="Environment", description="Energy products: output flows from production processes as defined in national accounts (ESA); typically products produced by extractive industries, refineries, power plants etc.", href="https://ec.europa.eu/eurostat/cache/metadata/en/env_pefa_esms.htm"},
            new EuroStatTable(){tableCode = "env_ac_pefasu", attributeName = "useEnergyResiduals", dataType="NaceRegionData", filters="unit=TJ&stk_flow=USE&prod_nrg=R00", unit="Terajoule", datasetName="Energy use - Energy residuals", esgFactor="Environment", description="Energy residuals: mainly energy in form of dissipative heat arising from the end use of energy products, flowing from the economy into the natural environment.", href="https://ec.europa.eu/eurostat/cache/metadata/en/env_pefa_esms.htm"},
            new EuroStatTable(){tableCode = "env_ac_aeint_r2", attributeName = "co2", dataType="NaceRegionData", filters="unit=G_EUR_CP&airpol=CO2&na_item=B1G", unit="Gram per Euro", datasetName="Emmisions of CO2", esgFactor="Environment", description="Air Emissions Accounts record the flows of residual gaseous and particulate materials emitted by resident units and flowing into the atmosphere. Residual gaseous and particulate materials are the physical flows of gaseous or particulate materials (‘air emissions’).", href="https://ec.europa.eu/eurostat/cache/metadata/en/env_ac_ainah_r2_esms.htm"}
        };

        public List<Nace> getAllNaces()
        {
            return naces;
        }  

        public List<Region> getAllRegions()
        {
            return regions;
        }  

        public List<EuroStatTable> getAllEuroStatTables()
        {
            return euroStatTables;
        }
    }

    public class MockData : BaseData
    {
        private List<NaceRegionData> naceRegionData = new List<NaceRegionData>() 
            { 
                new NaceRegionData() { regionId = 1, naceId =15,  year = 2018, genderPayGap = 14 },   
                new NaceRegionData() { regionId = 2, naceId = 15, year = 2018, genderPayGap = 6.4 },
            };
        
        private List<RegionData> regionData = new List<RegionData>() 
            { 
                new RegionData() { regionId = 1,  corruptionRate = 84, year = 2019, population = 5328212, gdp = 360300 },
                new RegionData() { regionId = 2, corruptionRate = 85, year = 2019, population = 10230185, gdp = 474194},
                new RegionData() { regionId = 3,  corruptionRate = 87, year = 2019, population = 5806081, gdp = 310002},
                new RegionData() { regionId = 4,  corruptionRate = 86, year = 2019, population = 5517919, gdp = 240557},
                new RegionData() { regionId = 5, corruptionRate = 0, year = 2019, population = 446824564, gdp = 13953148},
                new RegionData() { regionId = 1, year = 2018 },
                new RegionData() { regionId = 2, year = 2018 },
                new RegionData() { regionId = 3, year = 2018 },
                new RegionData() { regionId = 4, year = 2018 },
                new RegionData() { regionId = 5, year = 2018 },
                

            };   
    

        public new List<Nace> getAllNaces()
        {
            return this.naces.Take(5).ToList();
        }

        public new List<Region> getAllRegions()
        {
            return this.regions.Take(5).ToList();
        }

        public List<NaceRegionData> getNaceRegionData()
        {
            return this.naceRegionData;
        }

        public List<RegionData> getRegionData()
        {
            return this.regionData;
        }
    }
}
