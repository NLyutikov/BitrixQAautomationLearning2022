using atFrameWork2.BaseFramework.LogTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace atFrameWork2.BaseFramework
{
    public abstract class CaseCollectionBuilder
    {
        List<TestCase> CaseCollection { get; } = new List<TestCase>();

        public CaseCollectionBuilder()
        {
            CaseCollection.AddRange(GetCases());
        }

        abstract protected List<TestCase> GetCases();

        public static void ActivateTestCaseProvidersInstances(List<TestCase> resultCaseCollection)
        {
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
            IEnumerable<Type> subclassTypes = Assembly
                .GetAssembly(typeof(CaseCollectionBuilder))
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(CaseCollectionBuilder)));
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.

            foreach (var subClassType in subclassTypes)
            {
                try
                {
                    var instance = Activator.CreateInstance(subClassType) as CaseCollectionBuilder;
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
                    resultCaseCollection.AddRange(instance.CaseCollection);
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                }
            }
        }
    }
}
