-- Xóa các trigger trước
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'CapNhatFileHoanThanh_DeTai')
    DROP TRIGGER CapNhatFileHoanThanh_DeTai;
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'CapNhatFileHoanThanh_NCKH_SV')
    DROP TRIGGER CapNhatFileHoanThanh_NCKH_SV;

-- Xóa các bảng theo thứ tự ngược với phụ thuộc
IF OBJECT_ID('TienDo', 'U') IS NOT NULL DROP TABLE TienDo;
IF OBJECT_ID('BaoCaoThongKe', 'U') IS NOT NULL DROP TABLE BaoCaoThongKe;
IF OBJECT_ID('SinhVienNCKH', 'U') IS NOT NULL DROP TABLE SinhVienNCKH;
IF OBJECT_ID('NghienCuuKhoaHocSinhVien', 'U') IS NOT NULL DROP TABLE NghienCuuKhoaHocSinhVien;
IF OBJECT_ID('TacGiaCongBo', 'U') IS NOT NULL DROP TABLE TacGiaCongBo;
IF OBJECT_ID('CongBoKhoaHoc', 'U') IS NOT NULL DROP TABLE CongBoKhoaHoc;
IF OBJECT_ID('ThanhVienDeTai', 'U') IS NOT NULL DROP TABLE ThanhVienDeTai;
IF OBJECT_ID('DeTai_LinhVuc', 'U') IS NOT NULL DROP TABLE DeTai_LinhVuc;
IF OBJECT_ID('DeTaiNghienCuu', 'U') IS NOT NULL DROP TABLE DeTaiNghienCuu;
IF OBJECT_ID('SinhVien', 'U') IS NOT NULL DROP TABLE SinhVien;
IF OBJECT_ID('Lop', 'U') IS NOT NULL DROP TABLE Lop;
IF OBJECT_ID('GiangVien_LinhVuc', 'U') IS NOT NULL DROP TABLE GiangVien_LinhVuc;
IF OBJECT_ID('TapChiAnPham', 'U') IS NOT NULL DROP TABLE TapChiAnPham;
IF OBJECT_ID('BanQuanLy', 'U') IS NOT NULL DROP TABLE BanQuanLy;
IF OBJECT_ID('GiangVien', 'U') IS NOT NULL DROP TABLE GiangVien;
IF OBJECT_ID('Nganh', 'U') IS NOT NULL DROP TABLE Nganh;
IF OBJECT_ID('BoMon', 'U') IS NOT NULL DROP TABLE BoMon;
IF OBJECT_ID('Khoa', 'U') IS NOT NULL DROP TABLE Khoa;
IF OBJECT_ID('LinhVucNghienCuu', 'U') IS NOT NULL DROP TABLE LinhVucNghienCuu;
IF OBJECT_ID('OTP', 'U') IS NOT NULL DROP TABLE OTP;
IF OBJECT_ID('TaiKhoan', 'U') IS NOT NULL DROP TABLE TaiKhoan;

-- PHẦN 1: THIẾT KẾ BẢNG

CREATE TABLE TaiKhoan (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Email VARCHAR(255) UNIQUE NOT NULL,
    MatKhau NVARCHAR(255),
    VaiTro NVARCHAR(255) NOT NULL
);

CREATE TABLE OTP (
    ID INT PRIMARY KEY IDENTITY(1,1),
    TaiKhoanID INT NOT NULL,
    MaOTP VARCHAR(6) NOT NULL,
    ThoiGianTao DATETIME NOT NULL,
    ThoiGianHetHan DATETIME NOT NULL,
    TrangThai NVARCHAR(20) CHECK (TrangThai IN (N'ChuaSuDung', N'DaSuDung', N'HetHan')) DEFAULT N'ChuaSuDung',
    FOREIGN KEY (TaiKhoanID) REFERENCES TaiKhoan(ID) ON DELETE CASCADE
);

CREATE TABLE LinhVucNghienCuu (
    ID INT PRIMARY KEY IDENTITY(1,1),
    TenLinhVuc NVARCHAR(100) NOT NULL UNIQUE,
    MoTa NVARCHAR(500)
);

CREATE TABLE Khoa (
    ID INT PRIMARY KEY IDENTITY(1,1),
    MaKhoa VARCHAR(10) UNIQUE NOT NULL,
    TenKhoa NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(200),
    SoDienThoaiKhoa VARCHAR(15),
    EmailKhoa VARCHAR(100) UNIQUE,
    NgayThanhLap DATE,
    MoTa NVARCHAR(500)
);

CREATE TABLE BoMon (
    ID INT PRIMARY KEY IDENTITY(1,1),
    MaBoMon VARCHAR(10) UNIQUE NOT NULL,
    TenBoMon NVARCHAR(100) NOT NULL,
    MaKhoa VARCHAR(10) NOT NULL,
    SoDienThoai VARCHAR(15),
    Email VARCHAR(100) UNIQUE,
    MoTa NVARCHAR(500),
    FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa) ON DELETE CASCADE
);

CREATE TABLE Nganh (
    ID INT PRIMARY KEY IDENTITY(1,1),
    MaNganh VARCHAR(10) UNIQUE NOT NULL,
    TenNganh NVARCHAR(100) NOT NULL,
    MaKhoa VARCHAR(10) NOT NULL,
    MoTa NVARCHAR(500),
    LoaiNganh NVARCHAR(20) CHECK (LoaiNganh IN (N'Đại học', N'Cao đẳng', N'Sau đại học', N'Khác')) DEFAULT N'Đại học',
    NamBatDau INT,
    FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa) ON DELETE CASCADE
);

CREATE TABLE GiangVien (
    ID INT PRIMARY KEY IDENTITY(1,1),
    MaGV VARCHAR(10) UNIQUE NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    TaiKhoanID INT UNIQUE,
    SoDienThoai VARCHAR(15),
    MaBoMon VARCHAR(10),
    HocHam NVARCHAR(10) CHECK (HocHam IN (N'GS', N'PGS', N'TS', N'Không')) DEFAULT N'Không',
    HocVi NVARCHAR(20) CHECK (HocVi IN (N'ThS', N'TS', N'Tiến sĩ', N'Khác')) DEFAULT N'Khác',
    GioiTinh NVARCHAR(10) CHECK (GioiTinh IN (N'Nam', N'Nu', N'Khac')),
    ChucVu VARCHAR(50),
    TrangThai NVARCHAR(20) CHECK (TrangThai IN (N'Đang làm việc', N'Nghỉ hưu', N'Tạm nghỉ')) DEFAULT N'Đang làm việc',
    NgaySinh DATE,
    DiaChi NVARCHAR(200),
    NamBatDauLamViec INT,
    GhiChu TEXT,
    FOREIGN KEY (TaiKhoanID) REFERENCES TaiKhoan(ID),
    FOREIGN KEY (MaBoMon) REFERENCES BoMon(MaBoMon)
);

CREATE TABLE BanQuanLy (
    ID INT PRIMARY KEY IDENTITY(1,1),
    MaBQL VARCHAR(10) UNIQUE NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    TaiKhoanID INT UNIQUE,
    SoDienThoai VARCHAR(15),
    ChucVu NVARCHAR(50),
    MaGiangVien VARCHAR(10),
    TrangThai NVARCHAR(20) CHECK (TrangThai IN (N'Đang làm việc', N'Nghỉ việc')) DEFAULT N'Đang làm việc',
    FOREIGN KEY (TaiKhoanID) REFERENCES TaiKhoan(ID),
    FOREIGN KEY (MaGiangVien) REFERENCES GiangVien(MaGV)
);

CREATE TABLE TapChiAnPham (
    ID INT PRIMARY KEY IDENTITY(1,1),
    MaAnPham VARCHAR(10) UNIQUE NOT NULL,
    TenAnPham NVARCHAR(200) NOT NULL,
    LoaiAnPham NVARCHAR(50) CHECK (LoaiAnPham IN (N'Tạp chí quốc tế', N'Tạp chí trong nước', N'Sách chuyên khảo', N'Khác')) DEFAULT N'Khác',
    NamXuatBan INT,
    NhaXuatBan NVARCHAR(100),
    TrangThai NVARCHAR(20) CHECK (TrangThai IN (N'Đã xuất bản', N'Đang chờ duyệt')) DEFAULT N'Đang chờ duyệt',
    QuocGia NVARCHAR(50),
    NgonNgu NVARCHAR(50),
    ISSN_ISBN VARCHAR(20),
    MaGiangVien VARCHAR(10),
    FOREIGN KEY (MaGiangVien) REFERENCES GiangVien(MaGV)
);

CREATE TABLE GiangVien_LinhVuc (
    MaGV VARCHAR(10),
    ID_LinhVuc INT,
    PRIMARY KEY (MaGV, ID_LinhVuc),
    FOREIGN KEY (MaGV) REFERENCES GiangVien(MaGV) ON DELETE CASCADE,
    FOREIGN KEY (ID_LinhVuc) REFERENCES LinhVucNghienCuu(ID) ON DELETE CASCADE
);

CREATE TABLE Lop (
    ID INT PRIMARY KEY IDENTITY(1,1),
    MaLop VARCHAR(10) UNIQUE NOT NULL,
    TenLop NVARCHAR(20) NOT NULL,
    MaNganh VARCHAR(10) NOT NULL,
    NamNhapHoc INT NOT NULL,
    GiaoVienChuNhiem VARCHAR(10),
    TrangThai NVARCHAR(20) CHECK (TrangThai IN (N'Đang học', N'Tốt nghiệp', N'Giải thể')) DEFAULT N'Đang học',
    FOREIGN KEY (MaNganh) REFERENCES Nganh(MaNganh) ON DELETE CASCADE,
    FOREIGN KEY (GiaoVienChuNhiem) REFERENCES GiangVien(MaGV)
);

CREATE TABLE SinhVien (
    ID INT PRIMARY KEY IDENTITY(1,1),
    MaSV VARCHAR(10) UNIQUE NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    Email VARCHAR(100),
    MaLop VARCHAR(10) NOT NULL,
    NgaySinh DATE,
    SoDienThoai VARCHAR(15),
    DiaChi NVARCHAR(200),
    TrangThai NVARCHAR(20) CHECK (TrangThai IN (N'Đang học', N'Bảo lưu', N'Thôi học', N'Tốt nghiệp')) DEFAULT N'Đang học',
    FOREIGN KEY (MaLop) REFERENCES Lop(MaLop) ON DELETE CASCADE
);

CREATE TABLE DeTaiNghienCuu (
    ID INT PRIMARY KEY IDENTITY(1,1),
    MaDeTai VARCHAR(10) UNIQUE NOT NULL,
    TenDeTai NVARCHAR(200) NOT NULL,
    ChuNhiemDeTai VARCHAR(10),
    NgayBatDau DATE,
    NgayKetThuc DATE,
    KinhPhi DECIMAL(15, 2),
    TrangThai NVARCHAR(20) CHECK (TrangThai IN (N'Chờ duyệt', N'Đang thực hiện', N'Hoàn thành', N'Đã nghiệm thu', N'Hủy')) DEFAULT N'Chờ duyệt',
    NguonKinhPhi NVARCHAR(100),
    MucTieu TEXT,
    KetQuaDuKien TEXT,
    FileHoanThanh VARCHAR(255),
    FOREIGN KEY (ChuNhiemDeTai) REFERENCES GiangVien(MaGV)
);

CREATE TABLE DeTai_LinhVuc (
    MaDeTai VARCHAR(10),
    ID_LinhVuc INT,
    PRIMARY KEY (MaDeTai, ID_LinhVuc),
    FOREIGN KEY (MaDeTai) REFERENCES DeTaiNghienCuu(MaDeTai) ON DELETE CASCADE,
    FOREIGN KEY (ID_LinhVuc) REFERENCES LinhVucNghienCuu(ID) ON DELETE CASCADE
);

CREATE TABLE ThanhVienDeTai (
    MaDeTai VARCHAR(10),
    MaGV VARCHAR(10),
    VaiTro NVARCHAR(20) CHECK (VaiTro IN (N'Chủ nhiệm', N'Thành viên')) DEFAULT N'Thành viên',
    ThoiGianThamGia DATE,
    PRIMARY KEY (MaDeTai, MaGV),
    FOREIGN KEY (MaDeTai) REFERENCES DeTaiNghienCuu(MaDeTai) ON DELETE CASCADE,
    FOREIGN KEY (MaGV) REFERENCES GiangVien(MaGV) ON DELETE CASCADE
);

CREATE TABLE CongBoKhoaHoc (
    ID INT PRIMARY KEY IDENTITY(1,1),
    MaCongBo VARCHAR(10) UNIQUE NOT NULL,
    TieuDe NVARCHAR(200) NOT NULL,
    TomTat TEXT NOT NULL,
    TuKhoa NVARCHAR(200),
    NgonNgu NVARCHAR(50),
    LoaiCongBo NVARCHAR(20) CHECK (LoaiCongBo IN (N'TapChiQuocTe', N'HoiThaoQuocTe', N'TapChiTrongNuoc', N'KyYeuHoiNghi', N'Khac')) DEFAULT N'Khac',
    ISSN_ISBN VARCHAR(20),
    ChiMucKhoaHoc NVARCHAR(20) CHECK (ChiMucKhoaHoc IN (N'SCIE', N'SSCI', N'Scopus', N'GoogleScholar', N'IEEE', N'Springer', N'Elsevier', N'Khac')),
    ImpactFactor DECIMAL(5, 2),
    DOI VARCHAR(100) UNIQUE,
    NamCongBo INT,
    SoTrang INT,
    FileDinhKem VARCHAR(255)
);

CREATE TABLE TacGiaCongBo (
    ID INT PRIMARY KEY IDENTITY(1,1),
    MaCongBo VARCHAR(10) NOT NULL,
    MaGV VARCHAR(10),
    MaSV VARCHAR(10),
    GhiChu NVARCHAR(200),
    FOREIGN KEY (MaCongBo) REFERENCES CongBoKhoaHoc(MaCongBo) ON DELETE CASCADE,
    FOREIGN KEY (MaGV) REFERENCES GiangVien(MaGV),
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV),
    CONSTRAINT CheckAuthor CHECK (
        (MaGV IS NOT NULL AND MaSV IS NULL) OR 
        (MaGV IS NULL AND MaSV IS NOT NULL)
    )
);

CREATE TABLE NghienCuuKhoaHocSinhVien (
    ID INT PRIMARY KEY IDENTITY(1,1),
    MaNCKH VARCHAR(10) UNIQUE NOT NULL,
    TenHoatDong NVARCHAR(200) NOT NULL,
    GiangVienHuongDan VARCHAR(10),
    NgayBatDau DATE,
    NgayKetThuc DATE,
    KetQua NVARCHAR(100),
    TrangThai NVARCHAR(20) CHECK (TrangThai IN (N'Đang nghiên cứu', N'Đang thực hiện', N'Viết báo cáo', N'Hoàn thành', N'Chờ duyệt')) DEFAULT N'Chờ duyệt',
    KinhPhiHoatDong DECIMAL(15, 2),
    DiaDiem NVARCHAR(200),
    FileHoanThanh VARCHAR(255),
    FOREIGN KEY (GiangVienHuongDan) REFERENCES GiangVien(MaGV)
);

CREATE TABLE SinhVienNCKH (
    MaNCKH VARCHAR(10),
    MaSV VARCHAR(10),
    VaiTro NVARCHAR(50),
    ThoiGianThamGia DATE,
    KetQuaCaNhan NVARCHAR(100),
    PRIMARY KEY (MaNCKH, MaSV),
    FOREIGN KEY (MaNCKH) REFERENCES NghienCuuKhoaHocSinhVien(MaNCKH) ON DELETE CASCADE,
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV) ON DELETE CASCADE
);

ALTER TABLE NghienCuuKhoaHocSinhVien
ADD 
    MucTieuNghienCuu NVARCHAR(500) NOT NULL DEFAULT N'Chưa xác định',
    KetQuaDuKien NVARCHAR(500) NOT NULL DEFAULT N'Chưa xác định',
    TongQuanDeTai NVARCHAR(500) NOT NULL DEFAULT N'Chưa xác định',
    CapThietDeTai NVARCHAR(500) NOT NULL DEFAULT N'Chưa xác định';

CREATE TABLE BaoCaoThongKe (
    ID INT PRIMARY KEY IDENTITY(1,1),
    MaBaoCao VARCHAR(10) UNIQUE NOT NULL,
    TenBaoCao NVARCHAR(200) NOT NULL,
    LoaiBaoCao NVARCHAR(20) CHECK (LoaiBaoCao IN (N'Đề tài', N'Công bố KH', N'Sinh viên NCKH', N'Tổng hợp')) DEFAULT N'Tổng hợp',
    ThoiGianBatDau DATE,
    ThoiGianKetThuc DATE,
    NoiDung TEXT,
    NguoiLap INT,
    NgayLap DATE,
    DuongDanFile VARCHAR(255),
    TrangThaiDuyet NVARCHAR(20) CHECK (TrangThaiDuyet IN (N'Chưa duyệt', N'Đã duyệt', N'Từ chối')) DEFAULT N'Chưa duyệt',
    FOREIGN KEY (NguoiLap) REFERENCES TaiKhoan(ID)
);

CREATE TABLE TienDo (
    ID INT PRIMARY KEY IDENTITY(1,1),
    MaDeTai VARCHAR(10), -- Liên kết với DeTaiNghienCuu
    MaNCKH VARCHAR(10), -- Liên kết với NghienCuuKhoaHocSinhVien
    TrangThai NVARCHAR(20) CHECK (TrangThai IN (N'Đang thực hiện', N'Hoàn thành', N'Chờ duyệt')) DEFAULT N'Chờ duyệt',
    FileDinhKem VARCHAR(255),
    NguoiDuyet VARCHAR(10),
    FOREIGN KEY (MaDeTai) REFERENCES DeTaiNghienCuu(MaDeTai),
    FOREIGN KEY (MaNCKH) REFERENCES NghienCuuKhoaHocSinhVien(MaNCKH),
    FOREIGN KEY (NguoiDuyet) REFERENCES BanQuanLy(MaBQL),
    CONSTRAINT CHK_MaDeTai_Or_MaNCKH CHECK (
        (MaDeTai IS NOT NULL AND MaNCKH IS NULL) OR 
        (MaDeTai IS NULL AND MaNCKH IS NOT NULL)
    )
);

-- TRIGGER CHO DeTaiNghienCuu
GO
CREATE TRIGGER CapNhatFileHoanThanh_DeTai
ON DeTaiNghienCuu
AFTER UPDATE
AS
BEGIN
    IF UPDATE(TrangThai)
    BEGIN
        DECLARE @MaDeTai VARCHAR(10), @TrangThai NVARCHAR(20);
        SELECT @MaDeTai = MaDeTai, @TrangThai = TrangThai
        FROM inserted;

        IF @TrangThai = N'Hoàn thành'
        BEGIN
            UPDATE DeTaiNghienCuu
            SET FileHoanThanh = (
                SELECT TOP 1 FileDinhKem
                FROM TienDo
                WHERE MaDeTai = @MaDeTai AND TrangThai = N'Hoàn thành'
                ORDER BY ID DESC
            )
            WHERE MaDeTai = @MaDeTai;
        END
    END
END;
GO

-- TRIGGER CHO NghienCuuKhoaHocSinhVien
GO
CREATE TRIGGER CapNhatFileHoanThanh_NCKH_SV
ON NghienCuuKhoaHocSinhVien
AFTER UPDATE
AS
BEGIN
    IF UPDATE(TrangThai)
    BEGIN
        DECLARE @MaNCKH VARCHAR(10), @TrangThai NVARCHAR(20);
        SELECT @MaNCKH = MaNCKH, @TrangThai = TrangThai
        FROM inserted;

        IF @TrangThai = N'Hoàn thành'
        BEGIN
            UPDATE NghienCuuKhoaHocSinhVien
            SET FileHoanThanh = (
                SELECT TOP 1 FileDinhKem
                FROM TienDo
                WHERE MaNCKH = @MaNCKH AND TrangThai = N'Hoàn thành'
                ORDER BY ID DESC
            )
            WHERE MaNCKH = @MaNCKH;
        END
    END
END;
GO

-- PHẦN 2: CHÈN DỮ LIỆU

INSERT INTO TaiKhoan (Email, MatKhau, VaiTro) VALUES
('quanly1@tlus.edu.vn', NULL, N'Ban quan ly'),
('quanly2@tlus.edu.vn', NULL, N'Ban quan ly'),
('giangvien1@tlus.edu.vn', NULL, N'Giang vien'),
('giangvien2@tlus.edu.vn', NULL, N'Giang vien'),
('giangvien3@tlus.edu.vn', NULL, N'Giang vien'),
('giangvien4@tlus.edu.vn', NULL, N'Giang vien');

INSERT INTO OTP (TaiKhoanID, MaOTP, ThoiGianTao, ThoiGianHetHan, TrangThai) VALUES
(1, '123456', '2025-03-11 10:00:00', '2025-03-11 10:15:00', N'ChuaSuDung'),
(3, '654321', '2025-03-11 12:00:00', '2025-03-11 12:15:00', N'DaSuDung');

INSERT INTO LinhVucNghienCuu (TenLinhVuc, MoTa) VALUES
(N'Quản lý tài nguyên nước', N'Nghiên cứu quản lý và sử dụng hiệu quả tài nguyên nước'),
(N'Kỹ thuật thủy lợi', N'Ứng dụng kỹ thuật trong xây dựng công trình thủy lợi'),
(N'Môi trường và biến đổi khí hậu', N'Nghiên cứu tác động môi trường và biến đổi khí hậu'),
(N'Công nghệ thông tin trong thủy lợi', N'Ứng dụng CNTT trong quản lý thủy lợi');

INSERT INTO Khoa (MaKhoa, TenKhoa, DiaChi, SoDienThoaiKhoa, EmailKhoa, NgayThanhLap, MoTa) VALUES
('K01', N'Khoa Thủy lợi', N'175 Tây Sơn, Đống Đa, Hà Nội', '02438522201', 'khoathuyl@tlus.edu.vn', '1959-10-01', N'Khoa chuyên về thủy lợi'),
('K02', N'Khoa Công nghệ thông tin', N'175 Tây Sơn, Đống Đa, Hà Nội', '02438522202', 'khoacntt@tlus.edu.vn', '2000-01-01', N'Khoa chuyên về CNTT'),
('K03', N'Khoa Môi trường', N'175 Tây Sơn, Đống Đa, Hà Nội', '02438522203', 'khoamt@tlus.edu.vn', '1990-01-01', N'Khoa chuyên về môi trường');

INSERT INTO BoMon (MaBoMon, TenBoMon, MaKhoa, SoDienThoai, Email, MoTa) VALUES
('BM01', N'Bộ môn Thủy công', 'K01', '02438522301', 'bmtc@tlus.edu.vn', N'Chuyên về công trình thủy lợi'),
('BM02', N'Bộ môn CNTT ứng dụng', 'K02', '02438522302', 'bmcntt@tlus.edu.vn', N'Chuyên về ứng dụng CNTT'),
('BM03', N'Bộ môn Môi trường nước', 'K03', '02438522303', 'bmmt@tlus.edu.vn', N'Chuyên về môi trường nước');

INSERT INTO Nganh (MaNganh, TenNganh, MaKhoa, MoTa, LoaiNganh, NamBatDau) VALUES
('N01', N'Kỹ thuật Thủy lợi', 'K01', N'Đào tạo kỹ sư thủy lợi', N'Đại học', 1959),
('N02', N'Công nghệ thông tin', 'K02', N'Đào tạo kỹ sư CNTT', N'Đại học', 2000),
('N03', N'Kỹ thuật Môi trường', 'K03', N'Đào tạo kỹ sư môi trường', N'Đại học', 1990);

INSERT INTO GiangVien (MaGV, HoTen, TaiKhoanID, SoDienThoai, MaBoMon, HocHam, HocVi, GioiTinh, ChucVu, TrangThai, NgaySinh, DiaChi, NamBatDauLamViec, GhiChu) VALUES
('GV01', N'Nguyễn Thị Lan Anh', 3, '0912345678', 'BM01', N'PGS', N'TS', N'Nu', N'Trưởng bộ môn', N'Đang làm việc', '1975-05-10', N'Hà Nội', 2000, N'Chuyên gia thủy lợi'),
('GV02', N'Trần Văn Hùng', 4, '0912345679', 'BM02', N'Không', N'ThS', N'Nam', N'Giảng viên', N'Đang làm việc', '1985-08-15', N'Hà Nội', 2010, N'Chuyên gia CNTT'),
('GV03', N'Lê Thị Minh Ngọc', 5, '0912345680', 'BM03', N'TS', N'Tiến sĩ', N'Nu', N'Giảng viên', N'Đang làm việc', '1980-03-20', N'Hà Nội', 2005, N'Chuyên gia môi trường'),
('GV04', N'Phạm Quốc Bảo', 6, '0912345681', 'BM01', N'Không', N'TS', N'Nam', N'Giảng viên', N'Đang làm việc', '1982-11-25', N'Hà Nội', 2008, N'Chuyên gia thủy công');

INSERT INTO BanQuanLy (MaBQL, HoTen, TaiKhoanID, SoDienThoai, ChucVu, MaGiangVien, TrangThai) VALUES
('BQL01', N'Nguyễn Văn A', 1, '0912345601', N'Trưởng ban', NULL, N'Đang làm việc'),
('BQL02', N'Trần Thị B', 2, '0912345602', N'Phó ban', 'GV01', N'Đang làm việc');

INSERT INTO TapChiAnPham (MaAnPham, TenAnPham, LoaiAnPham, NamXuatBan, NhaXuatBan, TrangThai, QuocGia, NgonNgu, ISSN_ISBN, MaGiangVien) VALUES
('TC01', N'Tạp chí Khoa học Thủy lợi', N'Tạp chí trong nước', 2023, N'NXB Thủy lợi', N'Đã xuất bản', N'Việt Nam', N'Tiếng Việt', '1234-5678', 'GV01'),
('TC02', N'Journal of Water Resources', N'Tạp chí quốc tế', 2022, N'Springer', N'Đã xuất bản', N'Đức', N'Tiếng Anh', '9876-5432', 'GV02');

INSERT INTO GiangVien_LinhVuc (MaGV, ID_LinhVuc) VALUES
('GV01', 1),
('GV01', 2),
('GV02', 4),
('GV03', 3),
('GV04', 2);

INSERT INTO Lop (MaLop, TenLop, MaNganh, NamNhapHoc, GiaoVienChuNhiem, TrangThai) VALUES
('L01', N'TL64A', 'N01', 2020, 'GV01', N'Đang học'),
('L02', N'CNTT65B', 'N02', 2021, 'GV02', N'Đang học'),
('L03', N'MT66C', 'N03', 2022, 'GV03', N'Đang học');

INSERT INTO SinhVien (MaSV, HoTen, Email, MaLop, NgaySinh, SoDienThoai, DiaChi, TrangThai) VALUES
('SV01', N'Nguyễn Hoàng Anh', 'sv01@tlus.edu.vn', 'L01', '2002-01-15', '0987654321', N'Hà Nội', N'Đang học'),
('SV02', N'Trần Thị Thu Hà', 'sv02@tlus.edu.vn', 'L02', '2003-02-20', '0987654322', N'Hà Nội', N'Đang học'),
('SV03', N'Lê Minh Tuấn', 'sv03@tlus.edu.vn', 'L03', '2004-03-25', '0987654323', N'Hà Nội', N'Đang học');

INSERT INTO DeTaiNghienCuu (MaDeTai, TenDeTai, ChuNhiemDeTai, NgayBatDau, NgayKetThuc, KinhPhi, TrangThai, NguonKinhPhi, MucTieu, KetQuaDuKien) VALUES
('DT01', N'Nghiên cứu hệ thống thủy lợi Bắc Bộ', 'GV01', '2023-01-01', '2023-12-31', 500000000, N'Đang thực hiện', N'Bộ NN&PTNT', N'Tối ưu hóa hệ thống thủy lợi', N'Cải thiện hiệu suất tưới tiêu'),
('DT02', N'Ứng dụng AI trong quản lý nước', 'GV02', '2023-06-01', '2024-05-31', 300000000, N'Chờ duyệt', N'ĐH Thủy lợi', N'Tự động hóa quản lý nước', N'Tăng hiệu quả sử dụng nước'),
('DT03', N'Phân tích chất lượng nước sông Hồng', 'GV03', '2022-01-01', '2022-12-31', 200000000, N'Hoàn thành', N'Bộ TN&MT', N'Đánh giá chất lượng nước', N'Dữ liệu môi trường nước'),
('DT04', N'Xây dựng đập thủy lợi miền Trung', 'GV04', '2023-03-01', '2024-02-28', 700000000, N'Đang thực hiện', N'Bộ NN&PTNT', N'Tăng cường trữ nước', N'Hỗ trợ nông nghiệp');

INSERT INTO DeTai_LinhVuc (MaDeTai, ID_LinhVuc) VALUES
('DT01', 1),
('DT01', 2),
('DT02', 4),
('DT03', 3),
('DT04', 2);

INSERT INTO ThanhVienDeTai (MaDeTai, MaGV, VaiTro, ThoiGianThamGia) VALUES
('DT01', 'GV01', N'Chủ nhiệm', '2023-01-01'),
('DT01', 'GV04', N'Thành viên', '2023-01-01'),
('DT02', 'GV02', N'Chủ nhiệm', '2023-06-01'),
('DT03', 'GV03', N'Chủ nhiệm', '2022-01-01'),
('DT04', 'GV04', N'Chủ nhiệm', '2023-03-01');

INSERT INTO CongBoKhoaHoc (MaCongBo, TieuDe, TomTat, TuKhoa, NgonNgu, LoaiCongBo, ISSN_ISBN, ChiMucKhoaHoc, ImpactFactor, DOI, NamCongBo, SoTrang, FileDinhKem) VALUES
('CB01', N'Nghiên cứu thủy lợi bền vững', N'Tóm tắt về giải pháp thủy lợi', N'thủy lợi, bền vững', N'Tiếng Việt', N'TapChiTrongNuoc', '1234-5678', N'GoogleScholar', 1.5, '10.1234/cb01', 2023, 10, 'cb01.pdf'),
('CB02', N'AI in Water Management', N'Tóm tắt ứng dụng AI', N'AI, water', N'Tiếng Anh', N'TapChiQuocTe', '9876-5432', N'Scopus', 3.2, '10.5678/cb02', 2022, 15, 'cb02.pdf');

INSERT INTO TacGiaCongBo (MaCongBo, MaGV, MaSV, GhiChu) VALUES
('CB01', 'GV01', NULL, N'Tác giả chính'),
('CB01', NULL, 'SV01', N'Đồng tác giả'),
('CB02', 'GV02', NULL, N'Tác giả chính');

INSERT INTO NghienCuuKhoaHocSinhVien (MaNCKH, TenHoatDong, GiangVienHuongDan, NgayBatDau, NgayKetThuc, KetQua, TrangThai, KinhPhiHoatDong, DiaDiem) VALUES
('NCKH01', N'Nghiên cứu chất lượng nước sông Hồng', 'GV03', '2023-03-01', '2023-09-01', N'Tốt', N'Hoàn thành', 50000000, N'Hà Nội'),
('NCKH02', N'Ứng dụng GIS trong thủy lợi', 'GV01', '2023-10-01', '2024-03-31', NULL, N'Chờ duyệt', 30000000, N'Hà Nội');

INSERT INTO SinhVienNCKH (MaNCKH, MaSV, VaiTro, ThoiGianThamGia, KetQuaCaNhan) VALUES
('NCKH01', 'SV03', N'Thành viên', '2023-03-01', N'Phân tích mẫu nước'),
('NCKH02', 'SV01', N'Trưởng nhóm', '2023-10-01', N'Xây dựng bản đồ GIS');

INSERT INTO BaoCaoThongKe (MaBaoCao, TenBaoCao, LoaiBaoCao, ThoiGianBatDau, ThoiGianKetThuc, NoiDung, NguoiLap, NgayLap, DuongDanFile, TrangThaiDuyet) VALUES
('BC01', N'Báo cáo đề tài 2023', N'Đề tài', '2023-01-01', '2023-12-31', N'Tổng hợp tiến độ đề tài', 1, '2023-12-01', 'bc01.pdf', N'Đã duyệt'),
('BC02', N'Báo cáo công bố KH 2022', N'Công bố KH', '2022-01-01', '2022-12-31', N'Thống kê công bố', 3, '2023-01-10', 'bc02.pdf', N'Chưa duyệt');

INSERT INTO TienDo (MaDeTai, MaNCKH, TrangThai, FileDinhKem, NguoiDuyet) VALUES
('DT01', NULL, N'Đang thực hiện', 'tien_do_dt01_1.pdf', 'BQL01'),
('DT01', NULL, N'Hoàn thành', 'tien_do_dt01_hoan_thanh.pdf', 'BQL01'),
('DT02', NULL, N'Chờ duyệt', 'tien_do_dt02_1.pdf', 'BQL02'),
(NULL, 'NCKH01', N'Đang thực hiện', 'tien_do_nckh01_1.pdf', 'BQL01'),
(NULL, 'NCKH01', N'Hoàn thành', 'tien_do_nckh01_hoan_thanh.pdf', 'BQL01'),
(NULL, 'NCKH02', N'Chờ duyệt', 'tien_do_nckh02_1.pdf', 'BQL02');


ALTER TABLE CongBoKhoaHoc 
ADD TrangThai NVARCHAR(20) CHECK (TrangThai IN (N'Đã duyệt', N'Chờ duyệt')) DEFAULT N'Chờ duyệt';

UPDATE CongBoKhoaHoc
SET TrangThai = N'Chờ duyệt'
WHERE TrangThai IS NULL;


UPDATE NghienCuuKhoaHocSinhVien
SET 
    MucTieuNghienCuu = N'Nâng cao chất lượng nước sông Hồng',
    KetQuaDuKien = N'Chất lượng nước được cải thiện, đáp ứng tiêu chuẩn',
    TongQuanDeTai = N'Nghiên cứu về các yếu tố ảnh hưởng đến chất lượng nước sông Hồng, mục đích là tìm ra giải pháp cải thiện.',
    CapThietDeTai = N'Đề tài này rất cần thiết để bảo vệ môi trường và sức khỏe cộng đồng.'
WHERE MaNCKH = 'NCKH01';

UPDATE NghienCuuKhoaHocSinhVien
SET 
    MucTieuNghienCuu = N'Tối ưu hóa quản lý tài nguyên nước thông qua GIS',
    KetQuaDuKien = N'Tăng cường hiệu quả quản lý tài nguyên nước',
    TongQuanDeTai = N'Đề tài nghiên cứu ứng dụng công nghệ GIS trong quản lý tài nguyên nước, nhằm nâng cao hiệu quả sử dụng.',
    CapThietDeTai = N'Việc ứng dụng GIS là cần thiết để cải thiện quản lý tài nguyên nước trong bối cảnh biến đổi khí hậu.'
WHERE MaNCKH = 'NCKH02';