using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    internal interface IChanson
    {
        #region Propriétés
        //Obtient l’année de création de la chanson 
        int Annee { get; }
        //Obtient le nom de l’artiste ou du groupe ayant créé la chanson
        string Artiste { get; }
        //Obtient le format audio de la chanson par exemple AAC, MP3 ou WMA
        string Format { get; }
        //Obtient le nom de fichier de la chanson
        string NomFichier { get; }
        //Cette propriété calculée va obtenir les paroles de la chanson à partir d’un fichier texte
        string Paroles { get; }
        //Obtient le titre de la chanson
        string Titre { get; }
        #endregion

        #region Méthodes
        //Écrit les paroles passées en paramètre dans le fichier de la chanson
        void Ecrire(string pParoles);
        //Écrit uniquement l'entête de la chanson
        void EcrireEntete(StreamWriter pobjFichier);
        //Écrit uniquement les paroles de la chanson
        void EcrireParoles(StreamWriter pobjFichier, string pParoles);
        //Lecture de l’en-tête du fichier soit uniquement la première ligne
        void LireEntete();
        //Obtient les paroles à partir d'un fichier binaire déjà ouvert
        string LireParoles(StreamWriter pobjFichier);
        //Lit une ligne à partir du fichier passé en paramètre.
        void SauterEntete(StreamWriter pobjFichier);
        #endregion
    }
}
