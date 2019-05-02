using CERGI.MODULES.BAS;
using CRRH_BM.Areas.Financements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEMPLATE_SERVICE;

namespace CRRH_BM.Areas.Financements.Controllers
{
    public class NATURE_FINANCEMENTController : Controller
    {
        //
        // GET: /Financements/RUBRIQUE_FINANCEMENT/
        public ActionResult Index()
        {
            ViewBag.numDossier = "";
            return View();
        }
        
        public JsonResult ToJson(NATURE_FINANCEMENTVM o)
        {
            Message(ref o);
            JsonResult result = Json(o);
            result.MaxJsonLength = Int32.MaxValue;
            return result;
        }

        public void Message(ref NATURE_FINANCEMENTVM model)
        {
            model.ModuleMessage = SR_Module_Var_Principale.message;
            model.ModuleMessageTitre = SR_Module_Var_Principale.titreMessage;
            SR_Module_Var_Principale.message = "";
            SR_Module_Var_Principale.titreMessage = "";
        }

        public JsonResult GetViewModel()
        {
            var model = new NATURE_FINANCEMENTVM();
            return ToJson(model);
        }

        public void MessageBoxShow(string message, string titre, bool fin, ref NATURE_FINANCEMENTVM model)
        {
            model.returnMessage = message;
            model.titreMessage = titre;
            if (fin)
                model.statut = "end";
            if (!fin)
                model.statut = "ok";
        }

        public void MessageBoxShowError(string message, string titre, bool fin, ref NATURE_FINANCEMENTVM model)
        {
            model.returnMessage = message;
            model.titreMessage = titre;
            model.statut = "ko";
        }

        public bool QuestionOuiNonBoxShow(string message, string titre, int niveau, ref NATURE_FINANCEMENTVM model)
        {
            bool etatRetour = false;
            switch (niveau)
            {
                case 1:
                    if (!model.quizUn)
                    {
                        model.quizUn = true;
                        etatRetour = model.quizUn;
                    }
                    break;

                case 2:
                    if (!model.quizDeux)
                    {
                        model.quizDeux = true;
                        etatRetour = model.quizDeux;
                    }
                    break;
            }
            if (etatRetour)
            {
                model.returnMessage = message;
                model.titreMessage = titre;
                model.statut = "OuiNon";
            }
            else
            {
                model.returnMessage = "";
                model.titreMessage = "";
                model.statut = "";
            }
            return etatRetour;
        }

        public bool QuestionBoxShow(string message, string titre, int niveau, ref NATURE_FINANCEMENTVM model)
        {
            bool EtatRetour = false;
            switch (niveau)
            {
                case 1:
                    if (!model.quizUn)
                    {
                        model.quizUn = true;
                        EtatRetour = model.quizUn;
                    }
                    break;

                case 2:
                    if (!model.quizDeux)
                    {
                        model.quizDeux = true;
                        EtatRetour = model.quizDeux;
                    }
                    break;

                case 3:
                    if (!model.quizTrois)
                    {
                        model.quizTrois = true;
                        EtatRetour = model.quizTrois;
                    }
                    break;

                case 4:
                    if (!model.quizQuatre)
                    {
                        model.quizQuatre = true;
                        EtatRetour = model.quizQuatre;
                    }
                    break;

                case 5:
                    if (!model.quizCinq)
                    {
                        model.quizCinq = true;
                        EtatRetour = model.quizCinq;
                    }
                    break;
            }
            if (EtatRetour)
            {
                model.returnMessage = message;
                model.titreMessage = titre;
                model.statut = "quiz";
            }
            else
            {
                model.returnMessage = "";
                model.titreMessage = "";
                model.statut = "";
            }
            return EtatRetour;
        }

        //Fonction de chargement de la fenetre
        public JsonResult NATURE_FINANCEMENT_Load(NATURE_FINANCEMENTVM model)
        {
            NATURE_FINANCEMENTVM.NATURE_FINANCEMENT = new List<Dictionary<string, string>>();
            model.NATURE_FINANCEMENTDiv = TemplateService.ConstruireTableau(true, "NATURE_FINANCEMENT", NATURE_FINANCEMENTVM.entetes, NATURE_FINANCEMENTVM.NATURE_FINANCEMENT).ToString();
            return ToJson(model);
        }
	}
}