# Shopping Cart

- ApplicationUserRepository got implemented into UnitOfWork in case you need to work with the user account
- This was useful for having the create/manage user functionality under content management of admin view

# Order Header 

- Contains main information about the order. Order status, shipping address, pretty much anything that's a general overview about the order. 

# Order Details

- Self explanatory. Contains details about the order. 

	- quantity ordered
	- items ordered
	- the specifics that wouldn't be in order header

# Create Product

- Tested create product functionality with "Keith: A Book"
- Product uploads but if the image is a different size, the card will be a different size than the rest of the cards. 
## TO DO - set max size for img/card

# Customer Account
- Created and tested customer account. 

# Stripe
- Have not tested order functionality because I want to research more about Stripe and how testing with test cards work. Also, DLP alert concerns. 

# Estimated Completion Date 
- End of August 2023
