Feature: FLR - Quick API check 

A short summary of the feature

@tag1
Scenario: Check that the SolarFlare responds
	When I send a request to the FLR API
	Then The FLR API response should be 200

Scenario: Check that when I pass a date range to the FLR API that it returns data.
    When I send a date range request to the FLR API with start date "2024-02-19" and end date "2024-02-23"
	Then The FLR API should return dates with response status 200

Scenario: Check that the FLR API returns a 403 when the api key is wrong
    When I send an incorrect API call to the fLR API  
	Then The FLR API response should give me a 403 code



	 