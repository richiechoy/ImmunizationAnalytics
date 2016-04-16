using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PublicHealthAppTest
{
    [TestClass]
    public class UnitTest1
    {
        /*
        Immunization imm = new Immunization();
        imm.PatientId = "p";
        imm.State = "va";
        imm.VaccineId = "p";
        DataModel.AddImmunization(imm);


        State st = new State();
        st.AlphaCode = "alpha";
        st.FipsCode = "fips";
        st.Name = "va";
        DataModel.AddState(st);


        Patient pat = new Patient();
        pat.Id = "patID";
        pat.Age = "1337";
        DataModel.AddPatient(pat);


        Vaccine vac = new Vaccine();
        vac.Id = "vacID";
        vac.Name = "vorapede";
        DataModel.AddVaccine(vac);
        */

        /*Immunization imm = DataModel.GetImmunization(1);
        Patient pat = DataModel.GetPatient("TEST1");
        State st = DataModel.GetState("fips");
        Vaccine vac = DataModel.GetVaccine("TESTV01");

        Console.WriteLine(imm.ToString());
        Console.WriteLine(pat.ToString());
        Console.WriteLine(st.ToString());
        Console.WriteLine(vac.ToString());
        */

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
