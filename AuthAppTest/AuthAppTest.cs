using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

namespace AuthAppTest
{
    public class AuthAppTest
    {
        private Application _application;
        private AutomationBase _automation;

        public AuthAppTest()
        {
            _automation = new UIA3Automation();
        }

        [Fact]
        public void SuccessfulRegistrationTest()
        {
            _application = Application.Launch("\"C:\\Users\\faste\\source\\repos\\EducationProjects\\AuthApp\\bin\\Debug\\net8.0-windows\\AuthApp.exe\"");
            var mainWindow = _application.GetMainWindow(_automation);
            var loginBox = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("regLoginBox")).AsTextBox();
            var passwordBox = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("regPasswordBox")).AsTextBox();
            var confirmPasswordBox = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("confirmPasswordBox")).AsTextBox();
            var regButton = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("regButton")).AsButton();

            // Вводим данные для регистрации
            loginBox.Enter("user");
            passwordBox.Enter("W123!45a");
            confirmPasswordBox.Enter("W123!45a");
            regButton.Click();

            // Проверка сообщения об успешной регистрации
            var messageBox = mainWindow.FindFirstDescendant(cf => cf.ByClassName("WPFMessageBox")).AsWindow();
            Assert.Contains("Вы успешно зарегистрированы", messageBox.AsTextBox().Text);

            // Закрываем приложение
            _application.Close();
        }
    }

}
