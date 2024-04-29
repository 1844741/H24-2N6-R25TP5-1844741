using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    public class ChansonAAC : Chanson
    {
        #region Propriété
        public override string Format { get; }
        #endregion

        #region Méthodes
        //Initialise une instance avec les données passées en paramètres en appelant le constructeur de la classe de base.
        public ChansonAAC(string pNomFichier) : base(pNomFichier)
        {
            Format = "AAC";
        }

        //Initialise une instance avec les données passées en paramètres en appelant le constructeur de la classe de base.
        public ChansonAAC(string pRepertoire, string pArtiste, string pTitre, int pAnnee) : base(pRepertoire, pArtiste, pTitre, pAnnee)
        {
            Format = "AAC";
        }

        //Écrit une ligne dans le fichier passé en paramètre.
        //Cette ligne correspond à l’entête du fichier et contient les informations sur la chanson et représentées sous le format suivant :
        //TITRE = titre de la chanson : ARTISTE = nom de l’artiste : ANNÉE = année de création
        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            pobjFichier.WriteLine("TITRE = " + Titre + " : ARTISTE = " + " : ANNÉE = " + Annee);
        }

        //Encode les paroles reçues en paramètre au format AAC, ensuite écrit ses paroles encodées dans le fichier passé en paramètre.
        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            pobjFichier.WriteLine(OutilsFormats.EncoderAAC(pParoles));
        }

        //Lit la premiere ligne du fichier de la chanson et initialise les champs de la chanson (titre, artiste et année de création de la chanson)
        public override void LireEntete()
        {
            StreamReader reader = new StreamReader(m_nomFichier);
            string[] ligne = reader.ReadLine().Split(':');

            foreach (string l in ligne)
            {
                string[] info = l.Split('=');

                switch (info[0].Trim())
                {
                    case "TITRE":
                        m_titre = info[1].Trim();
                        break;
                    case "ARTISTE":
                        m_artiste = info[1].Trim();
                        break;
                    case "ANNÉE":
                        m_annee = int.Parse(info[1].Trim());
                        break;
                }
            }
        }

        //Récupère les paroles de la chanson à partir du fichier passé en paramètre, les décode selon le format AAC et les retourne
        public override string LireParoles(StreamReader pobjFichier)
        {
            return OutilsFormats.DecoderAAC(pobjFichier.ReadToEnd());
        }
        #endregion
    }
}
