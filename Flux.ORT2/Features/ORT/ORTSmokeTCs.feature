Feature: ORTSmokeTCs

Background: 
	Given User is logged In 'ORT'
	And User is on ORT landing Page

@Smoke
Scenario: Open analysis report

Given User navigates to page 'Analysis'
And User Opens analysis report 'Table A1 - Selected Information by State and Region'
When User navigates to Creation page of analysis report
But User enters following 'report details'
| FiscalYear1 | 
|    2016      |
And User runs report
Then Report should be generated in excel file

#Scenario: User can contact to support team via contact support
Given User navigates to page 'ContactSupport'
When User enters 'support details' as follows
|FirstName|LastName|EmailAddress|Subject|Message|
|Ross|Gray|ross@mediware.com|TestSubject|TestMessage|
And sends request to support
Then Request should be submitted successfully

#Scenario: User creates new blank report
Given User navigates to page 'Reports'
And tries to access 'New report'
When User enters following 'details' to create blank report
| Comments |
| Creating blank report through automation  |
And User saves report
Then Report should be created

#Scenario: User creates new report via import
Given User navigates to page 'Reports'
And tries to access 'New report'
When enter following 'details' to import report
| ReportSource         | FiscalYear | OmbudsManagerDatabase | AnnualWorkHoursperFTE | Comments |
| OmbudsManager Import | 2016       | OMBUDS_WI_STATE_7019   | 10                        |Creating report through OMB Import  |
And User saves report
Then Report should be created

#Scenario: User can apply filters available on reports page
#Given User navigates to page 'Reports'
#When User clears applied filter
#And User applies filter on 'Report Status' column// before coding check this step
#And User selects below 'Report Status'
#| Report Status |
#| Certified  |
#And User applies selected filter
#Then Selected filter should get applied
