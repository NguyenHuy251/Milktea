# Tổng quan dự án Quản lý quán trà sữa

## 1. Thông tin chung

Đây là ứng dụng desktop dành cho hoạt động quản lý và vận hành quán trà sữa. Phần mềm hỗ trợ tập trung các nghiệp vụ bán hàng, quản lý nhân sự, kho nguyên liệu và theo dõi doanh thu trên một hệ thống.

Ứng dụng phù hợp với mô hình quán có bán hàng tại bàn, cần quản lý món ăn, nguyên liệu, hóa đơn và phân quyền nhân viên.

## 2. Phạm vi chức năng

- Đăng nhập và phân quyền người dùng.
- Quản lý tài khoản và thông tin nhân viên.
- Quản lý danh mục, món ăn và công thức món.
- Quản lý bàn và hoạt động bán hàng tại bàn.
- Tạo, cập nhật và thanh toán hóa đơn bán.
- Quản lý nguyên liệu, tồn kho và nhà cung cấp.
- Nhập nguyên liệu và theo dõi hóa đơn nhập.
- Tổng hợp, xem và in báo cáo doanh thu.
- In hóa đơn hoặc xuất hóa đơn, báo cáo dưới dạng PDF.

## 3. Công nghệ và mô hình triển khai

- Ngôn ngữ: C#.
- Loại ứng dụng: Windows Forms desktop application.
- Nền tảng: .NET Framework 4.8.1.
- Cơ sở dữ liệu: Microsoft SQL Server.
- Thư viện xuất PDF: QuestPDF.
- Mô hình phần mềm: phân lớp giao diện, nghiệp vụ, truy cập dữ liệu và đối tượng dữ liệu.

Ứng dụng chạy trên máy tính Windows và kết nối đến cơ sở dữ liệu SQL Server của cửa hàng.

## 4. Cấu trúc dự án

Solution gồm bốn thành phần chính:

| Thành phần | Vai trò |
|---|---|
| `QuanLyQuanTraSua` | Giao diện và các màn hình thao tác của người dùng |
| `BUS` | Xử lý nghiệp vụ của hệ thống |
| `DAL` | Kết nối và làm việc với cơ sở dữ liệu |
| `DTO` | Mô hình dữ liệu dùng để trao đổi giữa các thành phần |

Các chức năng được tổ chức theo từng nhóm nghiệp vụ, giúp việc bảo trì và mở rộng hệ thống thuận lợi hơn.

## 5. Người dùng và phân quyền

Hệ thống có cơ chế đăng nhập và phân quyền theo loại tài khoản. Tài khoản quản trị có thể quản lý dữ liệu hệ thống và người dùng; tài khoản nhân viên được giới hạn theo nghiệp vụ được cấp quyền, chẳng hạn như bán hàng hoặc cập nhật thông tin liên quan.

Việc phân quyền hiện được thể hiện trong ứng dụng. Khi triển khai thực tế, quyền truy cập và chính sách bảo mật nên được rà soát thêm theo quy định của doanh nghiệp.

## 6. Giá trị sử dụng

- Tập trung dữ liệu vận hành của quán trên một hệ thống.
- Hỗ trợ nhân viên thao tác bán hàng và thanh toán nhanh hơn.
- Theo dõi nguyên liệu nhập vào và lượng tồn kho.
- Giảm việc quản lý thủ công bằng sổ sách hoặc bảng tính rời rạc.
- Cung cấp dữ liệu doanh thu phục vụ theo dõi hoạt động kinh doanh.
- Tạo nền tảng để bổ sung thêm chức năng khi quy mô quán phát triển.

## 7. Điều kiện vận hành

Để chạy ứng dụng cần có:

- Máy tính Windows có môi trường .NET Framework 4.8.1.
- SQL Server và cơ sở dữ liệu `QLyQuanTraSua`.
- Cấu hình kết nối giữa ứng dụng và máy chủ cơ sở dữ liệu.
- Bộ cài hoặc mã nguồn cùng các thư viện cần thiết của dự án.

Thông tin kết nối cơ sở dữ liệu hiện được cấu hình cho SQL Server instance `SQLEXPRESS01`. Khi triển khai trên máy khác, thông tin này có thể cần được điều chỉnh.

## 8. Phạm vi bảo trì và phát triển

Các hạng mục có thể tiếp tục cải thiện gồm:

- Nâng cao bảo mật tài khoản và mật khẩu.
- Hoàn thiện phân quyền ở nhiều lớp của hệ thống.
- Chuẩn hóa cấu hình triển khai và sao lưu dữ liệu.
- Bổ sung báo cáo, thống kê hoặc tích hợp các phương thức thanh toán khác.
- Tối ưu trải nghiệm người dùng và khả năng mở rộng khi số lượng cửa hàng tăng.

## 9. Tóm tắt

Đây là một hệ thống quản lý vận hành quán trà sữa quy mô nhỏ đến vừa, bao phủ các nghiệp vụ chính từ nhân sự, bán hàng, kho, nhập hàng đến báo cáo doanh thu. Dự án sử dụng công nghệ desktop phổ biến trong môi trường Windows và có cấu trúc phân lớp rõ ràng, phù hợp để tiếp tục bảo trì hoặc phát triển thêm theo nhu cầu kinh doanh.
