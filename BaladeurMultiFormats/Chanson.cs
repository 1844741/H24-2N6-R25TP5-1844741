using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    public abstract class Chanson : IChanson
    {
        #region Champs
        //Champ qui contient l'année
        private int m_annee;
        //Champ qui contient l'artiste
        private string m_artiste;
        //Champ qui contient le nom du fichier
        private string m_nomFichier;
        //Champ qui contient le titre
        private string m_titre;
        #endregion

        #region Propriétés
        //Obtient l’année de création de la chanson 
        public int Annee { get { return m_annee; } }
        //Obtient le nom de l’artiste ou du groupe ayant créé la chanson
        public string Artiste { get { return m_artiste; } }
        //Obtient le format audio de la chanson par exemple AAC, MP3 ou WMA
        public abstract string Format { get; }
        //Obtient le nom de fichier de la chanson
        public string NomFichier { get { return m_nomFichier; } }
        //Cette propriété calculée va obtenir les paroles de la chanson à partir d’un fichier texte
        public string Paroles { get; }
        //Obtient le titre de la chanson
        public string Titre { get { return m_titre; } }
        #endregion

        #region Méthodes
        //Initialise une instance, elle appelle la méthode LireEntete
        public Chanson(string pNomFichier)
        {
            m_nomFichier = pNomFichier;
            LireEntete();
        }
        //Le nom de fichier doit contenir le nom de répertoire , le nom de fichier et son format.
        public Chanson(string pRepertoire, string pArtiste, string pTitre, int pAnnee)
        {
            m_nomFichier = pRepertoire;
            m_artiste = pArtiste;
            m_titre = pTitre;
            m_annee = pAnnee;
        }

        //Écrit les paroles passées en paramètre dans le fichier de la chanson
        public void Ecrire(string pParoles)
        {
            StreamWriter writer = new StreamWriter(m_nomFichier, false);
            EcrireEntete(writer);
            EcrireParoles(writer, pParoles);
            writer.Close();
        }
        
        //Lit une ligne à partir du fichier passé en paramètre.
        public void SauterEntete(StreamReader pobjFichier)
        {
            pobjFichier.ReadLine();
        }

        //Lecture de l’en-tête du fichier soit uniquement la première ligne
        public abstract void LireEntete();
        //Écrit uniquement l'entête de la chanson
        public abstract void EcrireEntete(StreamWriter pobjFichier);
        //Écrit uniquement les paroles de la chanson
        public abstract void EcrireParoles(StreamWriter pobjFichier, string pParoles);
        //Obtient les paroles à partir d'un fichier binaire déjà ouvert
        public abstract string LireParoles(StreamReader pobjFichier);
        #endregion
    }
}
