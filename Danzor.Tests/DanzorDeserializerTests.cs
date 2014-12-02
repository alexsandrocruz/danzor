using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;
using Danzor.Tests.Helper;

namespace Danzor.Tests
{
    [TestClass]
    public class DanzorDeserializerTests
    {
        private dynamic nfe;

        [TestInitialize]
        public void Setup()
        {
            nfe = Factory.NFe28090708060730000190550020000001762000007303;
        }

        [TestMethod]
        public void validar_campo_infNFe()
        {
            Assert.IsNotNull(nfe.infNFe);
            Assert.IsNotNull(nfe.infNFe.ide);
            Assert.AreEqual("NFe28090708060730000190550020000001762000007303", nfe.infNFe["Id"]);
            Assert.AreEqual("1.10", nfe.infNFe["versao"]);
        }

        [TestMethod]
        public void validar_campo_ide()
        {
            Assert.AreEqual("1.3.2", nfe.infNFe.ide.verProc.Value);
            Assert.AreEqual("28", nfe.infNFe.ide.cUF.Value);
            Assert.AreEqual("200000730", nfe.infNFe.ide.cNF.Value);
            Assert.AreEqual("VENDA DE MERCADORIA ADQUIRIDA", nfe.infNFe.ide.natOp.Value);
            Assert.AreEqual("0", nfe.infNFe.ide.indPag.Value);
            Assert.AreEqual("2", nfe.infNFe.ide.serie.Value);
            Assert.AreEqual("176", nfe.infNFe.ide.nNF.Value);
            Assert.AreEqual(new DateTime(2009, 7, 1), nfe.infNFe.ide.dEmi.ToDateTime());
            Assert.AreEqual("1", nfe.infNFe.ide.tpNF.Value);
            Assert.AreEqual("2804805", nfe.infNFe.ide.cMunFG.Value);
            Assert.AreEqual("1", nfe.infNFe.ide.tpImp.Value);
            Assert.AreEqual("1", nfe.infNFe.ide.tpEmis.Value);
            Assert.AreEqual("3", nfe.infNFe.ide.cDV.Value);
            Assert.AreEqual("1", nfe.infNFe.ide.tpAmb.Value);
            Assert.AreEqual("1", nfe.infNFe.ide.finNFe.Value);
            Assert.AreEqual("3", nfe.infNFe.ide.procEmi.Value);
        }

        [TestMethod]
        public void validar_campo_emit()
        {
            Assert.IsNotNull(nfe.infNFe.emit);
            Assert.IsNotNull(nfe.infNFe.emit.enderEmit);
            Assert.IsNull(nfe.infNFe.emit.CPF);

            Assert.AreEqual("08060730000190", nfe.infNFe.emit.CNPJ.Value);
            Assert.AreEqual("FLEXLUX - PRODUTOS CERAMICOS LTDA. - EPP", nfe.infNFe.emit.xNome.Value);
            Assert.AreEqual("FLEXLUX", nfe.infNFe.emit.xFant.Value);
            Assert.AreEqual("271190191", nfe.infNFe.emit.IE.Value);
        }

        [TestMethod]
        public void validar_campo_emit_enderEmit()
        {
            Assert.IsNotNull(nfe.infNFe.emit);
            Assert.IsNotNull(nfe.infNFe.emit.enderEmit);
            Assert.IsNull(nfe.infNFe.emit.CPF);

            Assert.AreEqual("AV F, QUADRA 16, LOTES 06 E 07,", nfe.infNFe.emit.enderEmit.xLgr.Value);
            Assert.AreEqual("S/N", nfe.infNFe.emit.enderEmit.nro.Value);
            Assert.AreEqual("DIS IND SOCORRO", nfe.infNFe.emit.enderEmit.xBairro.Value);
            Assert.AreEqual("2804805", nfe.infNFe.emit.enderEmit.cMun.Value);
            Assert.AreEqual("Nossa Senhora do Socorro", nfe.infNFe.emit.enderEmit.xMun.Value);
            Assert.AreEqual("SE", nfe.infNFe.emit.enderEmit.UF.Value);
            Assert.AreEqual("49160000", nfe.infNFe.emit.enderEmit.CEP.Value);
            Assert.AreEqual("1058", nfe.infNFe.emit.enderEmit.cPais.Value);
            Assert.AreEqual("BRASIL", nfe.infNFe.emit.enderEmit.xPais.Value);
            Assert.AreEqual("7932568192", nfe.infNFe.emit.enderEmit.fone.Value);
        }

        [TestMethod]
        public void validar_campo_dest()
        {
            Assert.IsNotNull(nfe.infNFe.dest);
            Assert.IsNotNull(nfe.infNFe.dest.enderDest);

            Assert.AreEqual("01070694000104", nfe.infNFe.dest.CNPJ.Value);
            Assert.AreEqual("ARMIL MINERACAO DO NORDESTE LTDA", nfe.infNFe.dest.xNome.Value);
            Assert.AreEqual("200749102", nfe.infNFe.dest.IE.Value);
        }

        [TestMethod]
        public void validar_campo_dest_enderDest()
        {
            Assert.IsNotNull(nfe.infNFe.dest);
            Assert.IsNotNull(nfe.infNFe.dest.enderDest);


            Assert.IsTrue("RODOVIA RN 227" == nfe.infNFe.dest.enderDest.xLgr.Value);
            Assert.IsTrue("KM 05" == nfe.infNFe.dest.enderDest.nro.Value);
            Assert.IsTrue("NAO INFORMADO" == nfe.infNFe.dest.enderDest.xBairro.Value);
            Assert.IsTrue("2408904" == nfe.infNFe.dest.enderDest.cMun.Value);
            Assert.IsTrue("Parelhas" == nfe.infNFe.dest.enderDest.xMun.Value);
            Assert.IsTrue("RN" == nfe.infNFe.dest.enderDest.UF.Value);
            Assert.IsTrue("59360000" == nfe.infNFe.dest.enderDest.CEP.Value);
            Assert.IsTrue("1058" == nfe.infNFe.dest.enderDest.cPais.Value);
            Assert.IsTrue("BRASIL" == nfe.infNFe.dest.enderDest.xPais.Value);
            Assert.IsTrue("8434713021" == nfe.infNFe.dest.enderDest.fone.Value);
        }

        [TestMethod]
        public void validar_campo_det()
        {
            Assert.IsNotNull(nfe.infNFe.det[0]);
            Assert.AreEqual(350.0000, nfe.infNFe.det[0].prod.qCom.ToDouble());

            Assert.AreEqual("SUCATAS MADEIRA", nfe.infNFe.det[0].prod.cProd.Value);
            Assert.AreEqual("SUCATAS DE MADEIRA", nfe.infNFe.det[0].prod.xProd.Value);
            Assert.AreEqual("72041000", nfe.infNFe.det[0].prod.NCM.Value);
            Assert.AreEqual("00", nfe.infNFe.det[0].prod.EXTIPI.Value);
            Assert.AreEqual("72", nfe.infNFe.det[0].prod.genero.Value);
            Assert.AreEqual("6102", nfe.infNFe.det[0].prod.CFOP.Value);
            Assert.AreEqual("KG", nfe.infNFe.det[0].prod.uCom.Value);
            Assert.AreEqual(350.0000, nfe.infNFe.det[0].prod.qCom.ToDouble());
            Assert.AreEqual(5.0000, nfe.infNFe.det[0].prod.vUnCom.ToDouble());
            Assert.AreEqual(1750.00, nfe.infNFe.det[0].prod.vProd.ToDouble());
            Assert.AreEqual("UN", nfe.infNFe.det[0].prod.uTrib.Value);
            Assert.AreEqual(350.0000, nfe.infNFe.det[0].prod.qTrib.ToDouble());
            Assert.AreEqual(5.0000, nfe.infNFe.det[0].prod.vUnTrib.ToDouble());
        }

        [TestMethod]
        public void validar_campo_imposto()
        {
            Assert.IsNotNull(nfe.infNFe.det[0].imposto.ICMS);
            Assert.IsNotNull(nfe.infNFe.det[0].imposto.IPI);
            Assert.IsNotNull(nfe.infNFe.det[0].imposto.PIS);
            Assert.IsNotNull(nfe.infNFe.det[0].imposto.COFINS);
        }

        [TestMethod]
        public void validar_campo_imposto_ICMS()
        {
            Assert.AreEqual("0", nfe.infNFe.det[0].imposto.ICMS.ICMS00.orig.Value);
            Assert.AreEqual("00", nfe.infNFe.det[0].imposto.ICMS.ICMS00.CST.Value);
            Assert.AreEqual("3", nfe.infNFe.det[0].imposto.ICMS.ICMS00.modBC.Value);
        }

        [TestMethod]
        public void validar_campo_total()
        {
            Assert.IsNotNull(nfe.infNFe.total);

            Assert.AreEqual(1750.00, nfe.infNFe.total.ICMSTot.vBC.ToDouble());
            Assert.AreEqual(210.00, nfe.infNFe.total.ICMSTot.vICMS.ToDouble());
            Assert.AreEqual(0, nfe.infNFe.total.ICMSTot.vBCST.ToDouble());
            Assert.AreEqual(0, nfe.infNFe.total.ICMSTot.vST.ToDouble());
            Assert.AreEqual(1750.00, nfe.infNFe.total.ICMSTot.vProd.ToDouble());
            Assert.AreEqual(0.00, nfe.infNFe.total.ICMSTot.vFrete.ToDouble());
            Assert.AreEqual(0.00, nfe.infNFe.total.ICMSTot.vSeg.ToDouble());
            Assert.AreEqual(0.00, nfe.infNFe.total.ICMSTot.vDesc.ToDouble());
            Assert.AreEqual(0.00, nfe.infNFe.total.ICMSTot.vII.ToDouble());
            Assert.AreEqual(0.00, nfe.infNFe.total.ICMSTot.vIPI.ToDouble());
            Assert.AreEqual(28.88, nfe.infNFe.total.ICMSTot.vPIS.ToDouble());
            Assert.AreEqual(133.00, nfe.infNFe.total.ICMSTot.vCOFINS.ToDouble());
            Assert.AreEqual(0.00, nfe.infNFe.total.ICMSTot.vOutro.ToDouble());
            Assert.AreEqual(1750.00, nfe.infNFe.total.ICMSTot.vNF.ToDouble());
        }
    }
}
