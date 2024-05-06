using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaladeurMultiFormats
{
    internal interface IBaladeur
    {
        //Obtient le nombre de chansons
        int NbChansons { get; }

        //Affiche la liste des chansons dans la pListView passée en paramètre
        void AfficherLesChansons(ListView pListView);

        //Obtient la chanson à l’index pIndex passé en paramètre.
        Chanson ChansonAt(int pIndex);

        //Récupère la liste des fichiers dans le dossier Chansons, instancie selon le cas des objets des classes dérivées de la classe Chanson.
        void ConstruireLaListeDesChansons();

        //Instancie une ChansonAAC à partir de la chanson à l’index pIndex, enregistre les paroles et supprime le fichier du format précédent.
        //Elle utilise la méthode Ecrire pour enregistrer les paroles et la méthode File.Delete pour supprimer un fichier.
        void ConvertirVersAAC(int pIndex);

        //Instancie une ChansonMP3 à partir de la chanson à l’index pIndex, enregistre les paroles et supprime le fichier du format précédent.
        //Elle utilise la méthode Ecrire pour enregistrer les paroles et la méthode File.Delete pour supprimer un fichier.
        void ConvertirVersMP3(int pIndex);

        //Instancie une ChansonWMA à partir de la chanson à l’index pIndex, enregistre les paroles et supprime le fichier du format précédent.
        //Elle utilise la méthode Ecrire pour enregistrer les paroles et la méthode File.Delete pour supprimer un fichier.
        void ConvertirVersWMA(int pIndex);
    }
}
