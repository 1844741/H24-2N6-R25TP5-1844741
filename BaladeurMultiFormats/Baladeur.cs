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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void ConvertirVersMP3(int pIndex)
        {
            throw new NotImplementedException();
        }

        public void ConvertirVersWMA(int pIndex)
        {
            throw new NotImplementedException();
        }
    }
}
