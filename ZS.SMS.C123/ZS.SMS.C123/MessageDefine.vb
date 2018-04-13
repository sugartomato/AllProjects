Friend Class MessageDefine




    Private Shared list As List(Of Message) = New List(Of Message)()


    Friend Shared Function GetMessage(ByVal id As String)
        If (list.Count = 0) Then
            list.Add(New Message("9002", "未知命令"))
            list.Add(New Message("9012", "短信消息内容错误"))
            list.Add(New Message("9013", "目标地址错误"))
            list.Add(New Message("9014", "短信内容太长"))
            list.Add(New Message("9015", "路由错误"))
            list.Add(New Message("9016", "没有下发网关"))
            list.Add(New Message("9017", "定时时间错误"))
            list.Add(New Message("9018", "有效时间错误"))
            list.Add(New Message("9019", "无法拆分或者拆分错误"))
            list.Add(New Message("9020", "号码段错误"))
            list.Add(New Message("9021", "消息编号错误，这个和 PacketIndex 参数有关"))
            list.Add(New Message("9022", "用户不能发长短信(EsmClass 错误))"))
            list.Add(New Message("9023", "ProtocolID 错误"))
            list.Add(New Message("9024", "结构错误，一般是指长短信"))
            list.Add(New Message("9025", "短信编码错误"))
            list.Add(New Message("9026", "内容不是长短信"))
            list.Add(New Message("9027", "签名不对"))
            list.Add(New Message("9028", "目标网关不支持长短信"))
            list.Add(New Message("9029", "路由拦截"))
            list.Add(New Message("9030", "目标地址(手机号))太多"))
            list.Add(New Message("9031", "目标地址(手机号))太少"))
            list.Add(New Message("9032", "发送速度太快"))
            list.Add(New Message("9101", "验证失败，一般和用户名/密码/IP 地址相关"))
            list.Add(New Message("9102", "没有填写用户名"))
            list.Add(New Message("9103", "名字没找到"))
            list.Add(New Message("9104", "IP 地址不对"))
            list.Add(New Message("9105", "超过最大连接数，就是 tcp 连接数，http 也是一样的"))
            list.Add(New Message("9106", "协议版本错误"))
            list.Add(New Message("9107", "帐号无效，比如过期/禁用"))
            list.Add(New Message("9401", "计费错误"))
            list.Add(New Message("9402", "非法内容"))
            list.Add(New Message("9403", "黑名单"))
            list.Add(New Message("9404", "丢弃"))
            list.Add(New Message("9405", "Api 帐号丢失"))
            list.Add(New Message("9406", "配置拒绝，就是帐号设置了拒绝标记"))
            list.Add(New Message("9407", "帐号没有生成时间,这个属于非法帐号"))
            list.Add(New Message("9408", "消息超时，超过短信或帐号或系统设置的生存时间"))
            list.Add(New Message("9409", "由约束规则拒绝"))
            list.Add(New Message("9410", "状态报告超时"))
            list.Add(New Message("9411", "状态报告"))
            list.Add(New Message("9412", "帐号无效"))
            list.Add(New Message("9413", "重发拦截"))
            list.Add(New Message("9414", "转发时丢弃，比如该通道已经废弃"))
            list.Add(New Message("9415", "人工审核失败"))
            list.Add(New Message("9416", "可能是诈骗信息"))
            list.Add(New Message("9417", "不匹配模板"))
            list.Add(New Message("9418", "拒绝审核（审核功能可能关闭）"))
            list.Add(New Message("9419", "超过该手机号码的日发送次数限制"))
            list.Add(New Message("9501", "非法目标地址，即手机号"))
            list.Add(New Message("9502", "消息无法投入队列"))
            list.Add(New Message("9601", "上行路由失败"))
            list.Add(New Message("9602", "超过最大重试"))
            list.Add(New Message("9701", "通知失败"))
            list.Add(New Message("9702", "处理配置错误"))
            list.Add(New Message("9801", "投递地址错"))
            list.Add(New Message("9802", "无法连接到服务器"))
            list.Add(New Message("9803", "投递发送数据失败"))
            list.Add(New Message("9804", "投递接收结果失败"))
            list.Add(New Message("9902", "网关无此能力"))
            list.Add(New Message("9903", "二进制数据太长了；如网关没有特别说明，一般不能超过 140，"))
            list.Add(New Message("9904", "网关不支持 EsmClass 字段，或等同字段"))
            list.Add(New Message("9905", "网关不支持 ProtocolID 字段，或等同字段"))
            list.Add(New Message("9906", "网关不支持 UDHI 字段，或等同字段"))
            list.Add(New Message("9907", "网关支持 Letter 字段发送，但短信记录没有 letter"))
            list.Add(New Message("9908", "网关不存在"))
            list.Add(New Message("9909", "网关没有应答"))
            list.Add(New Message("9910", "网关不支持该短信编码"))
            list.Add(New Message("9911", "区域错误"))
        End If



        Dim obj = list.FirstOrDefault(Function(ByVal x) x.ID = id)
        If (Not obj Is Nothing) Then
            Return obj.Value
        End If
        Return String.Empty
    End Function


    Friend Class Message
        Public Sub New(_ID As String, _Value As String)
            Me.ID = _ID
            Me.Value = _Value
        End Sub
        Public Property ID As String
        Public Property Value As String
    End Class

End Class
