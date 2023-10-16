using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;

namespace COE.Common.DAL
{
    public class HistoryTableCommandTreeInterceptor : IDbCommandTreeInterceptor
    {
        public HistoryTableCommandTreeInterceptor(List<string> namesToIgnore = null)
        {
            if (namesToIgnore != null)
                _namesToIgnore = namesToIgnore;
        }
        public int ID { get; set; } = 100;
        private static List<string> _namesToIgnore = new List<string> { "StartTime", "EndTime" };

        public void TreeCreated(DbCommandTreeInterceptionContext interceptionContext)
        {
            if (interceptionContext.OriginalResult.DataSpace == DataSpace.SSpace)
            {
                var insertCommand = interceptionContext.Result as DbInsertCommandTree;
                if (insertCommand != null)
                {
                    var newSetClauses = GenerateSetClauses(insertCommand.SetClauses);

                    var newCommand = new DbInsertCommandTree(
                        insertCommand.MetadataWorkspace,
                        insertCommand.DataSpace,
                        insertCommand.Target,
                        newSetClauses,
                        insertCommand.Returning);

                    interceptionContext.Result = newCommand;
                }

                var updateCommand = interceptionContext.Result as DbUpdateCommandTree;
                if (updateCommand != null)
                {
                    var newSetClauses = GenerateSetClauses(updateCommand.SetClauses);

                    var newCommand = new DbUpdateCommandTree(
                        updateCommand.MetadataWorkspace,
                        updateCommand.DataSpace,
                        updateCommand.Target,
                        updateCommand.Predicate,
                        newSetClauses,
                        updateCommand.Returning);

                    interceptionContext.Result = newCommand;
                }
            }
        }

        private static ReadOnlyCollection<DbModificationClause> GenerateSetClauses(IList<DbModificationClause> modificationClauses)
        {
            var props = new List<DbModificationClause>(modificationClauses);
            props = props.Where(_ => !_namesToIgnore.Contains((((_ as DbSetClause)?.Property as DbPropertyExpression)?.Property as EdmProperty)?.Name)).ToList();

            var newSetClauses = new ReadOnlyCollection<DbModificationClause>(props);
            return newSetClauses;
        }

        public override bool Equals(object obj)
        {
            HistoryTableCommandTreeInterceptor interceptor = obj as HistoryTableCommandTreeInterceptor;
            if (this.ID == interceptor.ID)
                return true;

            return false;
        }
    }
}
