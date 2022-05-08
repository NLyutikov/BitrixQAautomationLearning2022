using atFrameWork2.BaseFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.BaseFramework;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace ATframework3demo.Pages.TestRunPage
{
    public class TestRunComponentBase : ComponentBase
    {
        const string configFileName = "settings.txt";
        CaseCollectionGenerator caseColBuilder = new CaseCollectionGenerator();

        protected bool RunButtonDisabled { get; set; }
#pragma warning disable CS8618 // свойство "CaseCollection", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
        protected List<TestCase> CaseCollection { get; set; }
#pragma warning restore CS8618 // свойство "CaseCollection", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
#pragma warning disable CS8618 // свойство "PortalUri", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
        protected string PortalUri { get; set; }
#pragma warning restore CS8618 // свойство "PortalUri", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
#pragma warning disable CS8618 // свойство "PortalUriBgColor", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
        protected string PortalUriBgColor { get; set; }
#pragma warning restore CS8618 // свойство "PortalUriBgColor", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
#pragma warning disable CS8618 // свойство "LoginBgColor", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
        protected string LoginBgColor { get; set; }
#pragma warning restore CS8618 // свойство "LoginBgColor", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
#pragma warning disable CS8618 // свойство "PwdBgColor", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
        protected string PwdBgColor { get; set; }
#pragma warning restore CS8618 // свойство "PwdBgColor", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
        protected User PortalUser { get; set; } = new User();
#pragma warning disable CS8618 // свойство "Modal", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
        [CascadingParameter] public IModalService Modal { get; set; }
#pragma warning restore CS8618 // свойство "Modal", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.

        protected void ShowLog(TestCase testCase)
        {
            var parameters = new ModalParameters();
            parameters.Add(nameof(LogViewComponent.TestCase), testCase);
            Modal.Show<LogViewComponent>($"Лог кейса '{testCase.Title}'", parameters);
        }

        protected void OnInputClick()
        {
            PortalUriBgColor = HelperMethods.GetHexColor(Color.White);
            LoginBgColor = HelperMethods.GetHexColor(Color.White);
            PwdBgColor = HelperMethods.GetHexColor(Color.White);
        }

        protected async void RunSelectedTests()
        {
            RunButtonDisabled = true;
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
            Uri portalUri = default;
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
            if (string.IsNullOrEmpty(PortalUri) || !Uri.TryCreate(PortalUri, UriKind.Absolute, out portalUri))
                PortalUriBgColor = HelperMethods.GetHexColor(Color.Red);
            else if (string.IsNullOrEmpty(PortalUser.Login))
                LoginBgColor = HelperMethods.GetHexColor(Color.Red);
            else if (string.IsNullOrEmpty(PortalUser.Password))
                PwdBgColor = HelperMethods.GetHexColor(Color.Red);
            else
            {
                File.WriteAllText(configFileName, $"{PortalUri}\r\n{PortalUser.Login}\r\n{PortalUser.Password}");
                var selectedCases = CaseCollection.FindAll(x => x.Node.IsChecked);
                
                if (selectedCases.Any())
                {
                    selectedCases.ForEach(x => x.Status = TestCaseStatus.waitingForExecute);
                    var portalInfo = new PortalInfo(portalUri, PortalUser);

                    foreach (var testCase in selectedCases)
                    {
                        await Task.Run(() =>
                        {
                            testCase.Execute(portalInfo, () => InvokeAsync(StateHasChanged));
                        });
                    }

                    return;
                }
            }
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
         
            RunButtonDisabled = false;
            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            CaseCollection = caseColBuilder.FrameworkCaseCollection;
            OnInputClick();
            
            if(File.Exists(configFileName))
            {
                string configContent = File.ReadAllText(configFileName);
                
                if (!string.IsNullOrEmpty(configContent))
                {
                    var parts = configContent.Split("\r\n", StringSplitOptions.None);
                    
                    if(parts.Count() > 2)
                    {
                        PortalUri = parts[0];
                        PortalUser.Login = parts[1];
                        PortalUser.Password = parts[2];
                    }
                }
            }
        }
    }
}
