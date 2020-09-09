namespace chenheyun.QYWeixin.Agents.Contacts
{
    /// <summary>
    /// 姓名,帐号,手机号,邮箱,所在部门,职位,性别,是否部门内领导,排序,别名,地址,座机,禁用,禁用项说明：(0-启用;1-禁用)
    /// </summary>
    public class BatchUserModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 所在部门Id，序列化用分号分隔。
        /// </summary>
        public int[] Parties { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// 性别，男女。
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 是否部门领导 (0-不是;1-是)，和部门一一对应，序列化用分号分隔。
        /// </summary>
        public int[] IsLeader { get; set; }
        /// <summary>
        /// 部门内排序，和部门一一对应，序列化用分号分隔。
        /// </summary>
        public int[] Order { get; set; }
        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// 地址。长度最大128个字符
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 座机。
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 禁用: (0-启用;1-禁用)
        /// </summary>
        public int Disabled { get; set; }

        public override string ToString()
        {
            return $"{Name},{UserId},{Mobile},{Email},{string.Join(";", Parties)},{Position},{Gender},{string.Join(";", IsLeader)},{string.Join(";", Order)},{Alias},{Address},{Telephone},{Disabled}";
        }
    }
}
