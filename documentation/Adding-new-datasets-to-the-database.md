# Adding new datasets to the database

The URLs we use to fetch JSON objects from Eurostats' API are build like this:

**static part**: [http://ec.europa.eu/eurostat/wdds/rest/data/v2.1/json/en/](http://ec.europa.eu/eurostat/wdds/rest/data/v2.1/json/en/)

**table code**: (EXAMPLE) env_ac_taxind2

**question mark**: ?

**precision**: precision=1&  (The & behind is between all filters)

**filters that are specific to the dataset**: (EXAMPLE) tax=ENV&unit=MIO_EUR

**filters that we generate from NACE and years**: &time=2015&time=2016&time=2017&time=2018&nace_r2=A&nace_r2=B&nace_r2=C&nace_r2=D&nace_r2=E&nace_r2=F&nace_r2=G&nace_r2=H&nace_r2=I&nace_r2=J&nace_r2=K&nace_r2=L&nace_r2=M&nace_r2=N&nace_r2=O&nace_r2=P&nace_r2=Q&nace_r2=R&nace_r2=S&nace_r2=T&nace_r2=U

To add new datasets follow these steps:

1) Find the table code you need from Giske's research or a new one you find

2) Enter the code in this query generator: [https://ec.europa.eu/eurostat/web/json-and-unicode-web-services/getting-started/query-builder](https://ec.europa.eu/eurostat/web/json-and-unicode-web-services/getting-started/query-builder)

3) Filter the data in a way you think we want it. For instance in the example above we filtered for Total environment taxes and chose million euros as the unit.

4) Press generate. This will make an URL without the static part.

5) Look at the generated query. See which filters are specific to this dataset. Typically this is a unit, and maybe something else, like in the example you also chose which environmental taxes to retrieve.

Let's show an example of this. From the example above:

env_ac_taxind2?precision=1&<span style="color:red">tax=ENV</span>&<span style="color:red">unit=MIO_EUR</span>&time=2015&time=2016&time=2017&time=2018&nace_r2=A&nace_r2=B&nace_r2=C&nace_r2=D&nace_r2=E&nace_r2=F&nace_r2=G&nace_r2=H&nace_r2=I&nace_r2=L&nace_r2=O&nace_r2=P&nace_r2=T&nace_r2=U

The ones in red are the two specific filters in this case.

6) Add them to the code:

Go to Services/DataSetProperties.cs. Find the constructor. There is a list of other datasets. Add the following:

filters.Add("_YOUR_TABLE_CODE_", "_FILTERS_SPECIFIC_TO_THE_DATASET_SEPARATED_BY_&");

That's it!

And no worries if a Nace-code is missing from the set. Their API is smart enough to deal with that.

# Nace codes

Here you can find all nace codes from eurostat: [https://ec.europa.eu/eurostat/ramon/nomenclatures/index.cfm?TargetUrl=LST_NOM_DTL&StrNom=NACE_REV2&StrLanguageCode=EN&IntPcKey=&StrLayoutCode=HIERARCHIC&IntCurrentPage=1](https://ec.europa.eu/eurostat/ramon/nomenclatures/index.cfm?TargetUrl=LST_NOM_DTL&StrNom=NACE_REV2&StrLanguageCode=EN&IntPcKey=&StrLayoutCode=HIERARCHIC&IntCurrentPage=1)
