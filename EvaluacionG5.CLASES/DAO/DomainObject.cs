using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
    /// <summary>
    /// Summary description for DomainObject.
    /// </summary>
    [Serializable()]
    public abstract class DomainObject
    {
        private bool _isPersisted;
        private bool _isDirty = true;
        private bool _isEmpty = true;
        private string _mapperName = String.Empty;

        public DomainObject()
        {
            CreateSubObjects();
        }

        public DomainObject(long id)
        {
            CreateSubObjects();
            Load(id);
        }

        public DomainObject(string mapperName)
        {
            _mapperName = mapperName;
            CreateSubObjects();
        }

        public DomainObject(long id, string mapperName)
        {
            _mapperName = mapperName;
            CreateSubObjects();
            Load(id);
        }

        #region Properties

        public bool IsPersisted { get { return _isPersisted; } set { _isPersisted = value; } }
        public bool IsDirty { get { return _isDirty; } }
        public bool IsEmpty { get { return _isEmpty; } set { _isEmpty = value; } }

        #endregion

        #region Protected Methods

        protected virtual void Insert()
        {
            DLBase dal = GetMapper();

            dal.Insert(this);
        }

        protected virtual void Update()
        {
            DLBase dal = GetMapper();

            dal.Update(this);
        }

        protected virtual void Delete()
        {
            DLBase dal = GetMapper();

            dal.Delete(this);
        }

        protected virtual void CreateSubObjects() { }
        protected virtual void LoadSubObjects() { }
        protected virtual void SaveSubObjects() { }

        protected virtual DLBase GetMapper()
        {
            return MapperRegistry.Instance.GetMapper(_mapperName);
        }

        protected virtual void RefreshFlags()
        {
            // Marcadores
            //_isPersisted = true;
            //_isDirty = true;
        }
        #endregion

        #region Public Methods

        public virtual void Load(long id)
        {
            DLBase dal = GetMapper();

            if (id <= 0)
                return;

            dal.Select(id, this);
            LoadSubObjects();
            RefreshFlags();
        }

        public virtual void Load(IDataReader dr)
        {
            DLBase dal = GetMapper();

            dal.Fill(this, dr);
            LoadSubObjects();
            RefreshFlags();
        }

        public virtual void Save()
        {
            if (_isDirty)
            {
                if (!_isPersisted)
                {
                    Insert();
                    _isPersisted = true;
                }
                else
                {
                    Update();
                }
            }
            //_isDirty = false;

            SaveSubObjects();
        }

        public void Erase()
        {
            if (_isPersisted)
                Delete();
            _isPersisted = false;
        }

        public void ForceErase()
        {
            Delete();
            _isPersisted = false;
        }

        #endregion
    }
}

