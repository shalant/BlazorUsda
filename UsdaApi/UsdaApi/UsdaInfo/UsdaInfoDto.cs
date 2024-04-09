namespace UsdaApi.UsdaInfo;

public class UsdaInfoDto
{
    public Datum[] data { get; set; }
}

public class Datum
{
    public string week_ending { get; set; }
    public string state_name { get; set; }
    public string country_code { get; set; }
    public string begin_code { get; set; }
    public string sector_desc { get; set; }
    public string zip_5 { get; set; }
    public string county_ansi { get; set; }
    public string state_alpha { get; set; }
    public string util_practice_desc { get; set; }
    public string domain_desc { get; set; }
    public string asd_desc { get; set; }
    public string freq_desc { get; set; }
    public string prodn_practice_desc { get; set; }
    public string end_code { get; set; }
    public string short_desc { get; set; }
    public string country_name { get; set; }
    public string Value { get; set; }
    public string reference_period_desc { get; set; }
    public string source_desc { get; set; }
    public string group_desc { get; set; }
    public string asd_code { get; set; }
    public string agg_level_desc { get; set; }
    public string Class_desc { get; set; }
    public string county_name { get; set; }
    public string region_desc { get; set; }
    public string watershed_desc { get; set; }
    public string state_ansi { get; set; }
    public string congr_district_code { get; set; }
    public string domaincat_desc { get; set; }
    public string watershed_code { get; set; }
    public string commodity_desc { get; set; }
    public string unit_desc { get; set; }
    public string load_time { get; set; }
    public string statisticcat_desc { get; set; }
    public string year { get; set; }
}
