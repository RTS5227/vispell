Chương trình này được tôi viết bằng **C#.NET**, nhằm mục đích **giảm bớt mệt nhọc cho vợ (pandaxinh, biên tập viên, phóng viên, nhà báo) khi duyệt qua các văn bản tiếng Việt có độ dài trung bình (vài trang A4)**.

# Hiện tại vispell có các tính năng sau #
  * Kiểm tra văn bản với tốc độ chấp nhận được khi bật đầy đủ tính năng (khoảng 1 giây cho một bài báo thông thường)
  * Các từ điển ở dạng text, dễ sửa, dễ thêm bớt mục từ cho người dùng bình thường
  * **Không cần cài đặt**, chạy trực tiếp trên các **máy tính dùng hệ điều hành Windows** đã **có sẵn .NET Framework 2.0** trở lên

  * đánh dấu các từ sai chính tả tiếng Việt (sử dụng từ điển các âm tiếng Việt của Hồ Ngọc Đức)
  * đánh dấu các từ "nghi vấn" (có từ điển các từ nghi vấn)
  * đánh dấu các từ ghép gồm 2 hoặc 3 âm tiết thường bị viết sai (có từ điển cho các từ dạng này, kiểu như "suy nghỉ", "lỉnh giải")
  * đánh dấu các từ có nhiều chữ in hoa liên tiếp (Sử dụng Regex)





# Giới thiệu thêm (dành cho dân IT) #
[chi tiết kỹ thuật](technical.md)
Chương trình chỉ được viết trong vòng vài giờ nên còn một số (tôi cho là) nhược điểm. Tuy nhiên phần lớn các nhược điểm này không ảnh hưởng tới người dùng cuối. Các bạn cần sử dụng vispell cứ yên tâm sử dụng. Các nhược điểm này chủ yếu là nhược điểm về kỹ thuật lập trình, độ tiện dùng:
  * Mã nguồn còn chưa gọn gàng (cần kiểm thử, refactor nếu cần)
  * Một số đoạn mã để tìm kiếm, thay thế, quét qua từ điển để xác định từ đúng sai còn chưa tối ưu, chạy chưa nhanh (cần review và chỉnh lại code)
  * Cập nhật từ điển bằng tay (Cần có khả năng sync từ điển online khi nào máy tính có nối mạng)
  * Giao diện chưa trực quan
  * Không có khả năng khuyến nghị sửa lỗi chính tả (Tôi là một kỹ sư IT, không phải chuyên gia ngôn ngữ nên chương trình được thực hiện nhằm giúp sức cho con người, chứ không có tham vọng thay thế con người chỉnh lại được hết lỗi viết văn. Do khả năng về lý thuyết ngôn ngữ cũng như độ phức tạp cao của ngữ pháp tiếng Việt nên thực chất thì tôi không muốn đưa vào tính năng khuyến nghị sửa lỗi hay kiểm tra ngữ pháp vì nó có thể làm chậm chương trình đi rất nhiều, và độ chính xác cũng không cao)


## Nâng cấp ##
Nếu điều kiện cho phép (VD: có tài trợ), tôi nghĩ đưa một phiên bản chương trình này dạng trang web sẽ có ích cho cộng đồng hơn.
  * Tiện, xài trên web luôn khỏi download mệt mỏi
  * Mọi người cùng đóng góp vào từ điển chung --> tăng chất lượng từ điển
  * Dễ phát tán, truyền miệng hơn

## Góp ý ##
Mời các bạn cho ý kiến đóng góp tại đây nhé: [contact](contact.md)  . Tôi rất vui lòng sửa để nâng cao chất lượng chương trình