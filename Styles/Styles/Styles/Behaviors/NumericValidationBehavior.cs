using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Styles.Behaviors
{
    public class NumericValidationBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty GroupProperty =
    BindableProperty.Create(nameof(Group), typeof(string), typeof(NumericValidationBehavior), null);
        public static readonly BindableProperty NameProperty =
          BindableProperty.Create(nameof(Name), typeof(string), typeof(NumericValidationBehavior), null);

        public string Group
        {
            get { return (string)GetValue(GroupProperty); }
            set { SetValue(GroupProperty, value); }
        }

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            double result;
            bool isValid = double.TryParse(args.NewTextValue, out result);
            if (isValid)
            {
                RemoveEffect(sender as Entry);
            }
            else
            {
                AddEffect(sender as Entry);
            }
            //((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }

        void AddEffect(View view)
        {
            var effect = GetEffect();
            if (effect != null)
            {
                var existingEffect = view.Effects.FirstOrDefault(e => e.ResolveId == effect.ResolveId);
                if (existingEffect == null)
                {
                    view.Effects.Add(GetEffect());
                }
            }
        }

        void RemoveEffect(View view)
        {
            var effect = GetEffect();
            if (effect != null)
            {
                var existingEffect = view.Effects.FirstOrDefault(e => e.ResolveId == effect.ResolveId);
                if (existingEffect != null)
                {
                    view.Effects.Remove(existingEffect);
                }
            }
        }

        Effect GetEffect()
        {
            if (!string.IsNullOrWhiteSpace(Group) && !string.IsNullOrWhiteSpace(Name))
            {
                return Effect.Resolve(string.Format("{0}.{1}", Group, Name));
            }
            return null;
        }
    }
}
