using System;
using System.Windows;

namespace Pos2Web
{
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : BaseAttachedProperty<Parent, Property>, new()
    {

        #region Public Events

        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        #endregion

        #region Public Properties
        private static Parent instance = new Parent();

        #endregion

        #region Public Properties

        public static Parent GetInstance()
        {
            return Instance;
        }

        #endregion

        #region Public Properties

        private static void SetInstance(Parent value)
        {
            Instance = value;
        }


        #endregion


        #region Attached property Definitions

        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value", typeof(Property), typeof(BaseAttachedProperty<Parent, Property>), new UIPropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));

        public static Parent Instance { get => Instance1; set => Instance1 = value; }
        public static Parent Instance1 { get => Instance3; set => Instance3 = value; }
        public static Parent Instance2 { get => Instance3; set => Instance3 = value; }
        public static Parent Instance3 { get => instance; set => instance = value; }

        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            GetInstance().OnValueChanged(d, e);

            GetInstance().ValueChanged(d, e);
        }

        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);

        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);

        #endregion


        #region Event Methods

        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }

        #endregion
    }

}
