using System;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Phone.Controls;

namespace EPSI.Tangram
{
    /// <summary>
    /// Page principale
    /// </summary>
    public partial class MainPage
    {
        /// <summary>
        /// Angle initial pour de la rotation
        /// </summary>
        private double _initialAngle;

        /// <summary>
        /// Degré de zoom initial
        /// </summary>
        private double _initialScale;

        /// <summary>
        /// Image en cours de manipulation
        /// </summary>
        private CompositeTransform _transform;

        /// <summary>
        /// Constructeur
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Déclenché lorsque l'utilisateur a posé ses deux doigts sur l'écran afin de zoomer ou rotater une image
        /// </summary>
        /// <param name="sender">Image sélectionnée par l'utilisateur</param>
        /// <param name="e"></param>
        private void GestureListener_OnPinchStarted(object sender, PinchStartedGestureEventArgs e)
        {
            Image image = (Image)sender;

            ContentPanel.Children.Remove(image);
            ContentPanel.Children.Add(image);

            _transform = (CompositeTransform)image.RenderTransform;

            _initialAngle = _transform.Rotation;
            _initialScale = _transform.ScaleX;
        }

        /// <summary>
        /// Déclenché lorsque l'utilisateur bouge ses deux doigts sur l'écran afin de zoomer ou rotater une image
        /// </summary>
        /// <param name="sender">Image sélectionnée par l'utilisateur</param>
        /// <param name="e"></param>
        private void GestureListener_OnPinchDelta(object sender, PinchGestureEventArgs e)
        {
            // Rotation
            _transform.Rotation = _initialAngle + e.TotalAngleDelta;

            // Zoom
            double newScale = _initialScale * e.DistanceRatio;
            _transform.ScaleX = _transform.ScaleY = newScale > 0.5 ? newScale : 0.5;
        }

        /// <summary>
        /// Déclenché lorsque l'utilisateur retire ses deux doigts de l'image
        /// </summary>
        /// <param name="sender">Image sélectionnée par l'utilisateur</param>
        /// <param name="e"></param>
        private void GestureListener_OnPinchCompleted(object sender, PinchGestureEventArgs e)
        {
            _transform = null;
        }

        /// <summary>
        /// Déclenché lorsque l'utilisateur pose un doigt sur l'écran pour déplacer une image
        /// </summary>
        /// <param name="sender">Image sélectionnée par l'utilisateur</param>
        /// <param name="e"></param>
        private void GestureListener_OnDragStarted(object sender, DragStartedGestureEventArgs e)
        {
            Image image = (Image)sender;

            ContentPanel.Children.Remove(image);
            ContentPanel.Children.Add(image);

            _transform = (CompositeTransform)image.RenderTransform;
        }

        /// <summary>
        /// Déclenché lorsque l'utilisateur bouge son doigt afin de déplacer l'image
        /// </summary>
        /// <param name="sender">Image sélectionnée par l'utilisateur</param>
        /// <param name="e"></param>
        private void GestureListener_OnDragDelta(object sender, DragDeltaGestureEventArgs e)
        {
            _transform.TranslateX += e.HorizontalChange;
            _transform.TranslateY += e.VerticalChange;
        }

        /// <summary>
        /// Déclenché lorsque l'utilisateur retire son doigt de l'imaga
        /// </summary>
        /// <param name="sender">Image sélectionnée par l'utilisateur</param>
        /// <param name="e"></param>
        private void GestureListener_OnDragCompleted(object sender, DragCompletedGestureEventArgs e)
        {
            _transform = null;
        }

        /// <summary>
        /// Déclenché lorsque l'utilisateur souhaite remettre le tangram à sa position initiale
        /// </summary>
        /// <param name="sender">MenuItem "réinitialiser le tangram"</param>
        /// <param name="e"></param>
        private void ApplicationBarResetMenuItem_OnClick(object sender, EventArgs e)
        {
            foreach (Image image in ContentPanel.Children)
            {
                CompositeTransform transform = (CompositeTransform) image.RenderTransform;
                transform.Rotation = 0.0;
                transform.TranslateX = 0.0;
                transform.TranslateY = 0.0;
                transform.ScaleX = 1.0;
                transform.ScaleY = 1.0;
            }
        }

        /// <summary>
        /// Déclenché lorsque l'utilisateur souhaite afficher la page de support de l'application
        /// </summary>
        /// <param name="sender">MenuItem "support de l'application"</param>
        /// <param name="e"></param>
        private void ApplicationBarSupportMenuItem_OnClick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AboutPage.xaml", UriKind.Relative));
        }
    }
}