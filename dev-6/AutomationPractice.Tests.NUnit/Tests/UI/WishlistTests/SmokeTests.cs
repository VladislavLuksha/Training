using AutomationPracticeTests.BaseTests;
using AutomationPracticeTests.Entities;
using AutomationPracticeTests.PageObjects.BasePages.Pages;
using AutomationPracticeTests.PageObjects.Pages;
using AutomationPracticeTests.Utilities.Enums;
using NUnit.Framework;

namespace AutomationPracticeTests.Tests.UI.NewFolder
{
    [TestFixture]
    public class SmokeTests : BaseTest
    {
        private HomePage HomePage => new HomePage();

        [Test]
        public void TestAdding_AddingToAutoCreatedWishlist_WishlistSuccessfullyCreatedAutomaticallyAndProductIsInTheList()
        {
            User user = UserCreator.GetUser(UserType.ChromeUser);
            string wishlistNameDelete = "product";
            string wishlistName = "My wishlist";

            // 1. Go to Authentication page
            AuthenticationPage authenticationPage = HomePage.OpenHomePage()
                .OpenAuthenticationPage();

            // 2. Login 
            MyAccountPage myAccountPage = authenticationPage.FillInLoginForm(user.Email, user.Password)
                .ClickSignInButton();

            // 3. Go to MyWishlists page
            MyWishlistsPage myWishlistsPage = myAccountPage.GoToMyWishlistsPage();

            if (myWishlistsPage.IsWishlistCreated(wishlistNameDelete))
                myWishlistsPage.DeleteMyWishlists();

            // 1. Verify that is no Wishlist in account settings
            Assert.IsTrue(myWishlistsPage.InvisibilityOfWishlistElement(), "Wishlist exists!");

            // 4. Go to Women page
            WomenPage womenPage = HomePage.GoToWomenPage();

            // 5. Choose any product and add to Wishlist button
            womenPage.AddDifferentProductsToWishlist(1);
          
            // 6. Go to MyWishlists page
            myWishlistsPage = HomePage.GoToMyWishlistsPage()
                .GoToMyWishlistsPage();

            bool isWishlistCreatedAutomaticallyActual = myWishlistsPage.IsWishlistCreated(wishlistName);

            // 2. Verify that wishlist was created automatically
            Assert.IsTrue(isWishlistCreatedAutomaticallyActual, "Wishlist wasn't created automatically!");

            // 7. Click MyWishlists Button
            myWishlistsPage.ClickMyWishlistsButton(wishlistName);

            bool isProductExistsActual = myWishlistsPage.IsProductExists();

            // 3. Verify that your product is in the list
            Assert.IsTrue(isProductExistsActual, "Product doesn't exist!");
        }

        [Test]
        public void TestAdding_AddingProductToWishlist_ProductSuccessfullyAddedToWishlist()
        {
            User user = UserCreator.GetUser(UserType.ChromeUser);
            string wishlistName = "product";
            string wishlistNameDefault = "My wishlist";

            // 1. Go to Authentication page
            AuthenticationPage authenticationPage = HomePage.OpenHomePage()
                .OpenAuthenticationPage();

            // 2. Login 
            MyAccountPage myAccountPage = authenticationPage.FillInLoginForm(user.Email, user.Password)
                .ClickSignInButton();

            // 3. Go to MyWishlists page
            MyWishlistsPage myWishlistsPage = myAccountPage.GoToMyWishlistsPage();

            if (myWishlistsPage.IsWishlistCreated(wishlistName))
                myWishlistsPage.DeleteMyWishlists();

            // 1. Verify that is no Wishlist in account settings
            Assert.IsTrue(myWishlistsPage.InvisibilityOfWishlistElement(), "Wishlist exists!");

            // 4. Create Wishlist in account settings
            myWishlistsPage.FillInputNewWishlist(wishlistName)
                .ClickSaveButton();

            bool isWishlistCreatedActual = myWishlistsPage.IsWishlistCreated(wishlistName);

            // 2. Verify that wishlist was created
            Assert.IsTrue(isWishlistCreatedActual, "Wishlist wasn't created!");

            // 5. Go to Women page
            WomenPage womenPage = HomePage.GoToWomenPage();

            // 6. Choose any product and add to Wishlist button
            womenPage.AddDifferentProductsToWishlist(1);

            // 7. Go to MyWishlists page
            myWishlistsPage = HomePage.GoToMyWishlistsPage()
                .GoToMyWishlistsPage();

            // 8. Click MyWishlists Button
            myWishlistsPage.ClickMyWishlistsButton(wishlistName);

            bool isProductExistsActual = myWishlistsPage.IsProductExists();

            // 3. Verify that your product was added to your Wishlist
            Assert.IsTrue(isProductExistsActual, "Product wasn't added to your Wishlist!");
        }

        [Test]
        public void TestAdding_AddingThreeDifferentProductsToCart_ThreeProductsSuccessfullyAddedToCart()
        {
            User user = UserCreator.GetUser(UserType.ChromeUser);
            string countOfProductsInCartExpected = "3 Products";
            string totalExpected = "$71.51";

            // 1. Go to Authentication page
            AuthenticationPage authenticationPage = HomePage.OpenHomePage()
                .OpenAuthenticationPage();

            // 2. Login 
            MyAccountPage myAccountPage = authenticationPage.FillInLoginForm(user.Email, user.Password)
                .ClickSignInButton();

            // 3. Go to Women Page 
            WomenPage womenPage = HomePage.GoToWomenPage();

            // 4. Add 3 different products to cart
            womenPage.AddDifferentProductsToCart(3);

            // 5. Go to cart
            CartPage cartPage = womenPage.GoToCartPage();

            var countOfProductsInCartActual = cartPage.GetCountProductsInCart();
            var totalActual = cartPage.GetTotalProductsInCart();

            // 1. Verify that all 3 products are in the cart and total is correct
            Assert.AreEqual(countOfProductsInCartExpected, countOfProductsInCartActual, "Count products in cart incorrect!");
            Assert.AreEqual(totalExpected, totalActual, "Total products in cart incorrect!");
        }
    }
}
