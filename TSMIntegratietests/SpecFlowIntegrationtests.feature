Feature: Integratietests met Gherkinsyntax

Scenario: Integratietest meerdere classes
	Given De knopen worden initieel gegenereerd
	When Ik klik  2 maal op de plusbutton
	Then toont het scherm 11 knopen 
    When Ik klik op het berekenen volgens methode1
	Then wordt de route berekend
	And wordt de route getoond
	And wordt de totale  afstand getoond
