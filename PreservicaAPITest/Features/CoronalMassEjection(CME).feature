Feature: CME - Quick API check

A short summary of the feature

@tag1
Scenario: Check that the CME API is reachable
	When I send a request to the CME API
	Then The CME API response status should be 200

Scenario: Check that when I pass a date range to the CME API that it returns data.
    When I send a date range request to the CME API with startDate "2025-03-9" and endDate "2025-03-23"
	Then The CME API should return dates with response status 200

Scenario: Check that CME API string returns a 400 request
    When I send an API request with an incorrect api key 
	Then The CME API response should give me a 403 code

