using Microsoft.Playwright;
using NasaPlaywrightUI.AutoData;

namespace NasaUITests
{
    public class NasaSignUpTests
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _context;
        private IPage _page;

        [SetUp]
        public async Task Setup()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            });

            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();
        }

        [Test]
        public async Task CompleteSignUpFlow()
        {
            await _page.GotoAsync("https://api.nasa.gov");

            // Going to click on the sign up link
            var signUpLink = await _page.QuerySelectorAsync(SignUpLocators.SignUpLink);
            Assert.IsNotNull(signUpLink, "Sign Up link not found!");
            await signUpLink.ClickAsync();

            // i've put these all togethor because theyre just filling out stuff, and this uses my test data too.
            await _page.FillAsync(SignUpLocators.FirstNameInput, TestData.firstName);
            await _page.WaitForTimeoutAsync(3000);
            await _page.WaitForSelectorAsync(SignUpLocators.LastNameInput);
            await _page.WaitForTimeoutAsync(3000);

            await _page.FillAsync(SignUpLocators.LastNameInput, TestData.lastName);
            await _page.WaitForTimeoutAsync(3000);
            await _page.WaitForSelectorAsync(SignUpLocators.EmailInput);
            await _page.WaitForTimeoutAsync(3000);
            await _page.FillAsync(SignUpLocators.EmailInput, TestData.email);


            // clicking on the submit button
            await _page.ClickAsync(SignUpLocators.SubmitButton);
            await _page.WaitForTimeoutAsync(3000);

            //Checking if everything is good here i.e. none of the entry feilds show.
            var userAssert = await _page.Locator(SignUpLocators.FirstNameInput).IsHiddenAsync();
            Assert.IsTrue(userAssert, "The username box should not be showing!");

            var userSurnameAssert = await _page.Locator(SignUpLocators.LastNameInput).IsHiddenAsync();
            Assert.IsTrue(userSurnameAssert, "The second name box should not be showing here!");

            var userEmailAssert = await _page.Locator(SignUpLocators.EmailInput).IsHiddenAsync();
            Assert.IsTrue(userSurnameAssert, "The email box should not be showing over here!");

            var userSubmitAssert = await _page.Locator(SignUpLocators.SubmitButton).IsHiddenAsync();
            Assert.IsTrue(userSurnameAssert, "The submit box should not be showing here!");

            //Here im just checking that the email is getting shown back to us (We already know the email field is not being show to us from above)
            var emailElements = _page.Locator($"text={TestData.email}");
            Assert.IsTrue(await emailElements.First.IsVisibleAsync(), "I expect the email to be on the screen, if not fail it!");
        }

        [TearDown]
        public async Task Teardown()
        {
            await _browser.CloseAsync();
            _playwright.Dispose();
        }
    }
}
