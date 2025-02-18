﻿using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    public class ChansonMP3 : Chanson
    {
        #region Propriété
        public override string Format { get; }
        #endregion

        #region Méthodes
        //Initialise une instance avec les données passées en paramètres en appelant le constructeur de la classe de base.
        public ChansonMP3(string pNomFichier) : base(pNomFichier)
        {
            Format = "mp3";
        }

        //Initialise une instance avec les données passées en paramètres en appelant le constructeur de la classe de base.
        public ChansonMP3(string pRepertoire, string pArtiste, string pTitre, int pAnnee) : base(pRepertoire, pArtiste, pTitre, pAnnee)
        {
            Format = "mp3";
            m_nomFichier = pRepertoire + "\\" + pTitre + "." + Format;
        }

        //Écrit une ligne dans le fichier passé en paramètre.
        //Cette ligne correspond à l’entête du fichier et contient les informations sur la chanson et représentées sous le format suivant :
        //Artiste | Année | Titre
        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            pobjFichier.WriteLine(Artiste + " | " + Annee + " | " + Titre);
        }

        //Encode les paroles reçues en paramètre au format MP3, ensuite écrit ses paroles encodées dans le fichier passé en paramètre.
        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            pobjFichier.WriteLine(OutilsFormats.EncoderMP3(pParoles));
        }

        //Lit la premiere ligne du fichier de la chanson et initialise les champs de la chanson (artiste, année de création et titre de la chanson)
        public override void LireEntete()
        {
            StreamReader reader = new StreamReader(m_nomFichier);
            string[] ligne = reader.ReadLine().Split('|');

            m_artiste = ligne[0].Trim();
            m_annee = int.Parse(ligne[1].Trim());
            m_titre = ligne[2].Trim();
            reader.Close();
        }

        //Récupère les paroles de la chanson à partir du fichier passé en paramètre, les décode selon le format MP3 et les retourne
        public override string LireParoles(StreamReader pobjFichier)
        {
            SauterEntete(pobjFichier);
            string paroles = OutilsFormats.DecoderMP3(pobjFichier.ReadToEnd());
            pobjFichier.Close();
            return paroles;
        }
        #endregion
    }
}
