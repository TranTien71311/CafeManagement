﻿using DelegateDecompiler;
using System.Linq.Expressions;

namespace Cafe_Management.Code
{
    public static class Function
    {
        public static Expression<Func<T, bool>> AndAlso<T>(
                this Expression<Func<T, bool>> expr1,
                Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
            var left = leftVisitor.Visit(expr1.Body);

            var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
            var right = rightVisitor.Visit(expr2.Body);

            return Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(left, right), parameter);
        }
        
    }
    public class ReplaceExpressionVisitor : ExpressionVisitor
    {
        private readonly Expression _oldValue;
        private readonly Expression _newValue;

        public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
        {
            _oldValue = oldValue;
            _newValue = newValue;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            // Thay thế tham số cũ bằng tham số mới
            return node == _oldValue ? _newValue : base.VisitParameter(node);
        }
    }
}
