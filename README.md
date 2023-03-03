# Open Polytechnic Technical Test - Senior Level

-----------------------------------------

IMPORTANT: Please note that this application was created with older technologies and has some compatibility issues with newer versions of Node.

It is recommended that you temporarily downgrade your version of Node to 12.18.4: https://nodejs.org/download/release/v12.18.4/

NPM latest version (8.19.2) is fine.

The application uses Angular 8. This should not cause a problem if running through IIS Express in Visual Studio, and your CLI version should not matter.

The backend uses .NET 6.0 and will require Visual Studio 2022. You can download the community version for free here: https://visualstudio.microsoft.com/vs/community/

If you have any problems running this exercise, please get in contact.

----------------------------------------- 

Please create a new branch off master (named with your first name or initials) and make your changes there.
Do NOT make any changes to the master branch

----------------------------------------- 

For this test you will be tasked with completing an application that allows customers to place online orders for a small cafe. It will consist of an Angular front-end and a C#/.NET back-end. The client is to take input and pass it to the API, and display the resulting total cost of the purchase. There are currently systems in place to get and display menu information and to create an order. It is not suggested that you edit these. Placing an order will currently not make an API request, and there is no logic for receiving it, calculating costs, and returning a response. 

There are some business rules that must be adhered to when creating your calculation logic.

-----------------------------------------

Multiple discounts can be applied to the same purchase. All discounts are cumulative in the order listed below.

1.	Senior citizens receive a 10% discount on any normal item ordered.
2.	Adults, including seniors, pay a 5% surcharge on any menu ordered from the childrens menu.
3.	For orders over $100, discount 5%
4.	Standard orders made on Thursday are given a 2% discount -- this should not apply to the weekend menu, for which you can consider orders placed outside the weekend being considerd an order placed in advance
5.	Items ordered from the catering menu should not receive any sort of discount regardless of who is ordering or when the order is placed.

Discounts should be considered cumulative, in the order presented above, and the original price rather than current subtotal used to apply them.

Example:
- A single senior citizen places an order for $120 on a Thursday. Their total should be $100.55.

-----------------------------------------

You will not need to implement unit tests, but you should design your system in a way that it would be testable in this way. You will be asked to speak to testing strategies as part of the interview.