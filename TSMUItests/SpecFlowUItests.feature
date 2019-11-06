Feature: SpecFlowTests met Gherkinsyntax
	
Scenario: Gherkin Toon verschillende routes
	Given De app is gestart
	When Ik klik  2 maal op de plusbutton
	And Ik laat de route berekenen volgens "methode1"
	Then toont het scherm de berekende route 
  	When Ik laat de route berekenen volgens "methode2" 
	Then toont het scherm de berekende route
	And de lengte van de latere route is groter dan die van de eerdere route

