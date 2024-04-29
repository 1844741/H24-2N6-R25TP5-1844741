using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    public class ChansonWMA : Chanson
    {
        #region Propriété & Champ
        private int m_codage;
        public override string Format { get; }
        #endregion

        #region Méthodes
        //Initialise une instance avec les données passées en paramètres en appelant le constructeur de la classe de base.
        public ChansonWMA(string pNomFichier) : base(pNomFichier)
        {
            Format = "WMA";
        }

        //Initialise une instance avec les données passées en paramètres en appelant le constructeur de la classe de base.
        public ChansonWMA(string pRepertoire, string pArtiste, string pTitre, int pAnnee) : base(pRepertoire, pArtiste, pTitre, pAnnee)
        {
            Format = "WMA";
        }

        //Écrit une ligne dans le fichier passé en paramètre.
        //Cette ligne correspond à l’entête du fichier et contient les informations sur la chanson et représentées sous le format suivant :
        //codage / année de création / titre de la chanson / nom de l’artiste
        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            pobjFichier.WriteLine(m_codage + " / " + Annee + " / " + Titre + " / " + Artiste);
        }

        //Encode les paroles reçues en paramètre au format WMA, ensuite écrit ses paroles encodées dans le fichier passé en paramètre.
        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            pobjFichier.WriteLine(OutilsFormats.EncoderWMA(pParoles, m_codage));
        }

        //Lit la premiere ligne du fichier de la chanson et initialise les champs de la chanson (codage, année de création, titre et artiste de la chanson)
        public override void LireEntete()
        {
            StreamReader reader = new StreamReader(m_nomFichier);
            string[] ligne = reader.ReadLine().Split('/');

            m_codage = int.Parse(ligne[0].Trim());
            m_annee = int.Parse(ligne[1].Trim());
            m_titre = ligne[2].Trim();
            m_artiste = ligne[3].Trim();
            reader.Close();
        }

        //Récupère les paroles de la chanson à partir du fichier passé en paramètre, les décode selon le format WMA et les retourne
        public override string LireParoles(StreamReader pobjFichier)
        {
            return OutilsFormats.DecoderWMA(pobjFichier.ReadToEnd(), m_codage);
        }
        #endregion
    }
}
