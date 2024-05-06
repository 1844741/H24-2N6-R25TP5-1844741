using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaladeurMultiFormats
{
    public class Baladeur : IBaladeur
    {
        private List<Chanson> m_colChansons;
        private const string NOM_RÉPERTOIRE = "Chansons";

        public int NbChansons { get { return m_colChansons.Count; } }

        public Baladeur()
        {
            m_colChansons = new List<Chanson>();
            ConstruireLaListeDesChansons();
        }

        public void AfficherLesChansons(ListView pListView)
        {
            pListView.Items.Clear();
            foreach (Chanson ch in m_colChansons)
            {
                ListViewItem item = new ListViewItem(ch.Artiste);
                item.SubItems.Add(ch.Titre);
                item.SubItems.Add(ch.Annee.ToString());
                item.SubItems.Add(ch.Format.ToUpper());
                pListView.Items.Add(item);
            }
        }

        public Chanson ChansonAt(int pIndex)
        {
            return m_colChansons[pIndex];
        }

        public void ConstruireLaListeDesChansons()
        {
            if (!Directory.Exists(NOM_RÉPERTOIRE))
                throw new Exception();

            foreach (string fichier in Directory.GetFiles(NOM_RÉPERTOIRE))
            {
                switch (fichier.Split('.')[1].ToLower())
                {
                    case "aac":
                        m_colChansons.Add(new ChansonAAC(fichier));
                        break;
                    case "mp3":
                        m_colChansons.Add(new ChansonMP3(fichier));
                        break;
                    case "wma":
                        m_colChansons.Add(new ChansonWMA(fichier));
                        break;
                    default: throw new Exception();
                }
            }
        }

        public void ConvertirVersAAC(int pIndex)
        {
            IChanson ch = ChansonAt(pIndex);
            ChansonAAC nouvelleChanson = new ChansonAAC(NOM_RÉPERTOIRE, ch.Artiste, ch.Titre, ch.Annee);
            nouvelleChanson.Ecrire(ch.Paroles);
            
            File.Delete(ch.NomFichier);
        }

        public void ConvertirVersMP3(int pIndex)
        {
            IChanson ch = ChansonAt(pIndex);
            ChansonMP3 nouvelleChanson = new ChansonMP3(NOM_RÉPERTOIRE, ch.Artiste, ch.Titre, ch.Annee);
            nouvelleChanson.Ecrire(ch.Paroles);

            File.Delete(ch.NomFichier);
        }

        public void ConvertirVersWMA(int pIndex)
        {
            IChanson ch = ChansonAt(pIndex);
            ChansonWMA nouvelleChanson = new ChansonWMA(NOM_RÉPERTOIRE, ch.Artiste, ch.Titre, ch.Annee);
            nouvelleChanson.Ecrire(ch.Paroles);

            File.Delete(ch.NomFichier);
        }
    }
}
