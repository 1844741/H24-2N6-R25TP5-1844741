using System;
using System.Windows.Forms;
using System.IO;


namespace BaladeurMultiFormats
{
    // Étapes de  réalisation :
    // Étape #1 : Définir les classes Chanson et ChasonAAC

    public partial class FrmPrincipal : Form
    {
        public const string APP_INFO = "1844741";

        #region Propriété : MonHistorique
        public Historique MonHistorique { get; }
        public Baladeur MonBaladeur { get; }
        #endregion
        //---------------------------------------------------------------------------------
        #region FrmPrincipal
        public FrmPrincipal()
        {
            InitializeComponent();
            Text += APP_INFO;
            MonHistorique = new Historique();
            MonBaladeur = new Baladeur();
            // À COMPLÉTER...
            MonBaladeur.AfficherLesChansons(lsvChansons);
            lsvChansons.SelectedIndices.Add(0);
            MettreAJourSelonContexte();
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Méthode : MettreAJourSelonContexte
        private void MettreAJourSelonContexte()
        {
            // À COMPLÉTER...
            IChanson chanson = null;
            string paroles = string.Empty;

            if (lsvChansons.SelectedIndices.Count > 0)
            {
                chanson = MonBaladeur.ChansonAt(lsvChansons.SelectedIndices[0]);
                paroles = chanson.Paroles;
            }

            txtParoles.Text = paroles;
            lblNbChansons.Text = MonBaladeur.NbChansons.ToString();

            MnuFormatConvertirVersAAC.Enabled = chanson != null && chanson.Format != "aac";
            MnuFormatConvertirVersMP3.Enabled = chanson != null && chanson.Format != "mp3";
            MnuFormatConvertirVersWMA.Enabled = chanson != null && chanson.Format != "wma";
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Événement : LsvChansons_SelectedIndexChanged
        private void LsvChansons_SelectedIndexChanged(object sender, EventArgs e)
        {
            MettreAJourSelonContexte();
            if (lsvChansons.SelectedIndices.Count > 0)
                MonHistorique.Add(new Consultation(DateTime.Now, MonBaladeur.ChansonAt(lsvChansons.SelectedIndices[0])));
        }
        #endregion

        //---------------------------------------------------------------------------------
        #region Méthodes : Convertir vers les formats AAC, MP3 ou WMA
        private void MnuFormatConvertirVersAAC_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            // À COMPLÉTER...
            int i = lsvChansons.SelectedIndices[0];
            MonHistorique.Clear();
            MonBaladeur.ConvertirVersAAC(i);
            MonBaladeur.ConstruireLaListeDesChansons();
            MonBaladeur.AfficherLesChansons(lsvChansons);
            lsvChansons.SelectedIndices.Add(i);
        }
        private void MnuFormatConvertirVersMP3_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            // À COMPLÉTER...
            int i = lsvChansons.SelectedIndices[0];
            MonHistorique.Clear();
            MonBaladeur.ConvertirVersMP3(i);
            MonBaladeur.ConstruireLaListeDesChansons();
            MonBaladeur.AfficherLesChansons(lsvChansons);
            lsvChansons.SelectedIndices.Add(i);
        }
        private void MnuFormatConvertirVersWMA_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            // À COMPLÉTER...
            int i = lsvChansons.SelectedIndices[0];
            MonHistorique.Clear();
            MonBaladeur.ConvertirVersWMA(i);
            MonBaladeur.ConstruireLaListeDesChansons();
            MonBaladeur.AfficherLesChansons(lsvChansons);
            lsvChansons.SelectedIndices.Add(i);
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Historique
        private void MnuSpécialHistorique_Click(object sender, EventArgs e)
        {
            FrmHistorique objFormulaire = new FrmHistorique(MonHistorique);
            objFormulaire.ShowDialog();
        }
        #endregion
         //---------------------------------------------------------------------------------
        #region Méthodes : MnuFichierQuitter_Click
        //---------------------------------------------------------------------------------
        private void MnuFichierQuitter_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
