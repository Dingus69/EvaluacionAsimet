using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EvaluacionG5.COMMON
{
    public class ItemCollection : CollectionBase
    {
        /// <summary>
        /// Agrega el item con el mensaje de seleccionar
        /// un item de la lista.
        /// </summary>
        public ItemCollection InsertSelectionItem()
        {
            if (List.Count > 0)
                List.Insert(0, Utiles.GetSelectionItem());
            return this;
        }

        /// <summary>
        /// Agrega siempre el item con el mensaje de seleccionar
        /// un item de la lista.
        /// </summary>
        public ItemCollection InsertSelectionItemAlways()
        {
            if (List.Count >= 0)
                List.Insert(0, Utiles.GetSelectionItem());
            return this;
        }

        /// <summary>
        /// Ordena la colleccion por el campo Text.
        /// Ordenamiento por Inserción.
        /// </summary>
        public ItemCollection SortByText()
        {
            ItemCollection colOrdenada = new ItemCollection();

            for (int i = 0; i < this.Count; i++)
            {
                int j;

                for (j = 0; j < colOrdenada.Count; j++)
                {
                    if (string.Compare(this[i].Text, colOrdenada[j].Text, true) <= 0)
                    {
                        colOrdenada.Insert(j, this[i]);
                        break;
                    }
                }

                if (this.Count <= 0 || j == colOrdenada.Count)
                {
                    colOrdenada.Add(this[i]);
                }
            }

            return colOrdenada;
        }

        public virtual Item this[int index]
        {
            get { return ((Item)List[index]); }
            set { List[index] = value; }
        }

        public virtual int Add(Item value)
        {
            return (List.Add(value));
        }

        public virtual int IndexOf(Item value)
        {
            return (List.IndexOf(value));
        }

        public virtual void Insert(int index, Item value)
        {
            List.Insert(index, value);
        }

        public virtual void Remove(Item value)
        {
            List.Remove(value);
        }

        public virtual bool Contains(Item value)
        {
            // If value is not of type DomainObject, this will return false.
            return (List.Contains(value));
        }

    }
}
