# Giới thiệu #

Tôi trình bày về kỹ thuật thực hiện chương trình ở đây. Nếu đọc code chương trình này, các bạn mới học C# có thể nắm được một số kỹ thuật như: đọc file đi kèm chương trình, xử lý string, regular expression đơn giản với C#, nhúng Browser lên winform để làm việc hiển thị ... Các kỹ thuật này là các đầu mục lớn ở phía dưới, các bạn có thể theo dõi dễ dàng.


# Kỹ thuật #
## Sử dụng file text cấu trúc đơn giản ##
Sử dụng các file text có cấu trúc đơn giản để lưu trữ dữ liệu từ điển. Các mục từ trong file phân cách bởi dấu enter.
Chương trình có thể đọc các file này dễ dàng bằng cách dùng string.ReadAllText();

Tôi cũng đang xem xét và kiểm thử hiệu năng để sử dụng từ điển những cụm từ có nghĩa trong từ điển của Hồ Ngọc Đức (xem thread này http://groups.google.com/group/phpvietnam/browse_thread/thread/e635382f1bdca7b2?hl=vi )

(Dự định) sử dụng thêm dữ liệu từ đây http://www.xulyngonngu.com/sharing/

(Dự định) Cho phép cộng đồng cập nhật các từ blacklist, greylist


## Sử dụng Regular Expression ##
vispell sử dụng regex để: tìm kiếm các từ sai dạng viết hoa liên tiếp (VD: CHi tiền, CHương trìNH), thay thế trong chuỗi không phân biệt hoa thường (vì nếu dùng string.Replace() sẽ gặp vấn đề không thay thế chuỗi có cả chữ hoa và chữ thường được)

## Sử dụng web browser để trình bày kết quả ##
vispell sử dụng WebBrowser (wrap một cái IE browser) để hiển thị kết quả tìm kiếm cho dễ dàng. Việc này giúp tạo thuận lợi để tôi có thể đánh dấu các lỗi sai trong chuỗi kết quả dễ dàng, trình bày giao diện phong phú, có thể thay đổi kiểu dáng (màu sắc những từ bị sai, từ nghi vấn, đưa từ sai vào từ điển bằng cách gọi javascript)
Tôi sử dụng cả jquery và blueprint CSS framework trong file html dùng để hiển thị kết quả.

Các kỹ thuật xử lý với webBrowser control cần thiết có thể xem ở đây:
  * http://msdn.microsoft.com/en-us/library/a0746166(VS.85).aspx#Mtps_DropDownFilterText
  * http://msdn.microsoft.com/en-us/library/system.windows.forms.htmldocument(VS.85).aspx
  * http://msdn.microsoft.com/en-us/library/system.windows.forms.htmldocument.attacheventhandler(VS.85).aspx
  * http://msdn.microsoft.com/en-us/library/system.windows.forms.htmldocument.invokescript(VS.85).aspx


Một số chú ý:
  * Nếu gọi `InvokeScript`, hàm bên JS trả về Html Element, ta có thể cast sang  `HtmlElement` (trong C#)
  * Cần bắt event nào bên Browser rồi xử lý bằng mã C#, có thể dùng `AttachEventHandler()` (HtmlElement, HtmlDocument đều có hàm này). Nhớ rằng `AttachEventHandler()` cần gọi sau khi Browser đã load xong HtmlDocument, do vậy nên gọi hàm này trong `HtmlDocumentCompleted event handler`.
  * Muốn cho js bên Browser gọi được hàm của Form C# cần: đặt `SecurityAtrribute cho class của Form C#, đặt COMVisible cho Form C#, gán webBrowser1.ObjectForScripting = đối tượng Form C#;`

```
[PermissionSet(SecurityAction.Demand, Name="FullTrust")]
[System.Runtime.InteropServices.ComVisibleAttribute(true)]
public class Form1 : Form {}

webBrowser1.ObjectForScripting = this; // gán trong Form_Load()
```