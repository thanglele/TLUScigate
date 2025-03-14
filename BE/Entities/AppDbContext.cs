using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TLUScience.Entities;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BanQuanLy> BanQuanLies { get; set; }

    public virtual DbSet<BaoCaoThongKe> BaoCaoThongKes { get; set; }

    public virtual DbSet<BoMon> BoMons { get; set; }

    public virtual DbSet<CongBoKhoaHoc> CongBoKhoaHocs { get; set; }

    public virtual DbSet<DeTaiNghienCuu> DeTaiNghienCuus { get; set; }

    public virtual DbSet<GiangVien> GiangViens { get; set; }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<LinhVucNghienCuu> LinhVucNghienCuus { get; set; }

    public virtual DbSet<Lop> Lops { get; set; }

    public virtual DbSet<Nganh> Nganhs { get; set; }

    public virtual DbSet<NghienCuuKhoaHocSinhVien> NghienCuuKhoaHocSinhViens { get; set; }

    public virtual DbSet<OTP> OTPs { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    public virtual DbSet<SinhVienNCKH> SinhVienNCKHs { get; set; }

    public virtual DbSet<TacGiaCongBo> TacGiaCongBos { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<TapChiAnPham> TapChiAnPhams { get; set; }

    public virtual DbSet<ThanhVienDeTai> ThanhVienDeTais { get; set; }

    public virtual DbSet<TienDo> TienDos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=36.50.176.198;Database=tluscigate;User Id=applicationSQL;Password=E+PrX4hDu+OucniK5PGNDfwfXn9hUuzo3RQJpXcFeSQ=;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BanQuanLy>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__BanQuanL__3214EC27869BDD8F");

            entity.ToTable("BanQuanLy");

            entity.HasIndex(e => e.MaBQL, "UQ__BanQuanL__35216F7FDC751231").IsUnique();

            entity.HasIndex(e => e.TaiKhoanID, "UQ__BanQuanL__9A124B649B7BCC37").IsUnique();

            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.MaBQL)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaGiangVien)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Đang làm việc");

            entity.HasOne(d => d.MaGiangVienNavigation).WithMany(p => p.BanQuanLies)
                .HasPrincipalKey(p => p.MaGV)
                .HasForeignKey(d => d.MaGiangVien)
                .HasConstraintName("FK__BanQuanLy__MaGia__6E96540A");

            entity.HasOne(d => d.TaiKhoan).WithOne(p => p.BanQuanLy)
                .HasForeignKey<BanQuanLy>(d => d.TaiKhoanID)
                .HasConstraintName("FK__BanQuanLy__TaiKh__6DA22FD1");
        });

        modelBuilder.Entity<BaoCaoThongKe>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__BaoCaoTh__3214EC27C974A2DB");

            entity.ToTable("BaoCaoThongKe");

            entity.HasIndex(e => e.MaBaoCao, "UQ__BaoCaoTh__25A9188DD464A8CE").IsUnique();

            entity.Property(e => e.DuongDanFile)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LoaiBaoCao)
                .HasMaxLength(20)
                .HasDefaultValue("Tổng hợp");
            entity.Property(e => e.MaBaoCao)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NoiDung).HasColumnType("text");
            entity.Property(e => e.TenBaoCao).HasMaxLength(200);
            entity.Property(e => e.TrangThaiDuyet)
                .HasMaxLength(20)
                .HasDefaultValue("Chưa duyệt");

            entity.HasOne(d => d.NguoiLapNavigation).WithMany(p => p.BaoCaoThongKes)
                .HasForeignKey(d => d.NguoiLap)
                .HasConstraintName("FK__BaoCaoTho__Nguoi__33408412");
        });

        modelBuilder.Entity<BoMon>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__BoMon__3214EC276043AD5C");

            entity.ToTable("BoMon");

            entity.HasIndex(e => e.Email, "UQ__BoMon__A9D105340325EE80").IsUnique();

            entity.HasIndex(e => e.MaBoMon, "UQ__BoMon__B783EFA7E69EDB66").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MaBoMon)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaKhoa)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TenBoMon).HasMaxLength(100);

            entity.HasOne(d => d.MaKhoaNavigation).WithMany(p => p.BoMons)
                .HasPrincipalKey(p => p.MaKhoa)
                .HasForeignKey(d => d.MaKhoa)
                .HasConstraintName("FK__BoMon__MaKhoa__54D68207");
        });

        modelBuilder.Entity<CongBoKhoaHoc>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__CongBoKh__3214EC279DF09A70");

            entity.ToTable("CongBoKhoaHoc");

            entity.HasIndex(e => e.DOI, "UQ__CongBoKh__C03580FC13E784F9").IsUnique();

            entity.HasIndex(e => e.MaCongBo, "UQ__CongBoKh__E45C1FBE9BFBD889").IsUnique();

            entity.Property(e => e.ChiMucKhoaHoc).HasMaxLength(20);
            entity.Property(e => e.DOI)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FileDinhKem)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ISSN_ISBN)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ImpactFactor).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.LoaiCongBo)
                .HasMaxLength(20)
                .HasDefaultValue("Khac");
            entity.Property(e => e.MaCongBo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NgonNgu).HasMaxLength(50);
            entity.Property(e => e.TieuDe).HasMaxLength(200);
            entity.Property(e => e.TomTat).HasColumnType("text");
            entity.Property(e => e.TuKhoa).HasMaxLength(200);
        });

        modelBuilder.Entity<DeTaiNghienCuu>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__DeTaiNgh__3214EC2758315E15");

            entity.ToTable("DeTaiNghienCuu", tb => tb.HasTrigger("CapNhatFileHoanThanh_DeTai"));

            entity.HasIndex(e => e.MaDeTai, "UQ__DeTaiNgh__9F967D5A290741E1").IsUnique();

            entity.Property(e => e.ChuNhiemDeTai)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FileHoanThanh)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.KetQuaDuKien).HasColumnType("text");
            entity.Property(e => e.KinhPhi).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.MaDeTai)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MucTieu).HasColumnType("text");
            entity.Property(e => e.NguonKinhPhi).HasMaxLength(100);
            entity.Property(e => e.TenDeTai).HasMaxLength(200);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Chờ duyệt");

            entity.HasOne(d => d.ChuNhiemDeTaiNavigation).WithMany(p => p.DeTaiNghienCuus)
                .HasPrincipalKey(p => p.MaGV)
                .HasForeignKey(d => d.ChuNhiemDeTai)
                .HasConstraintName("FK__DeTaiNghi__ChuNh__0C26B6F1");

            entity.HasMany(d => d.ID_LinhVucs).WithMany(p => p.MaDeTais)
                .UsingEntity<Dictionary<string, object>>(
                    "DeTai_LinhVuc",
                    r => r.HasOne<LinhVucNghienCuu>().WithMany()
                        .HasForeignKey("ID_LinhVuc")
                        .HasConstraintName("FK__DeTai_Lin__ID_Li__0FF747D5"),
                    l => l.HasOne<DeTaiNghienCuu>().WithMany()
                        .HasPrincipalKey("MaDeTai")
                        .HasForeignKey("MaDeTai")
                        .HasConstraintName("FK__DeTai_Lin__MaDeT__0F03239C"),
                    j =>
                    {
                        j.HasKey("MaDeTai", "ID_LinhVuc").HasName("PK__DeTai_Li__7B891B1AA04CCECA");
                        j.ToTable("DeTai_LinhVuc");
                        j.IndexerProperty<string>("MaDeTai")
                            .HasMaxLength(10)
                            .IsUnicode(false);
                    });
        });

        modelBuilder.Entity<GiangVien>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__GiangVie__3214EC27CB17EBCE");

            entity.ToTable("GiangVien");

            entity.HasIndex(e => e.MaGV, "UQ__GiangVie__2725AEF29FF48A77").IsUnique();

            entity.HasIndex(e => e.TaiKhoanID, "UQ__GiangVie__9A124B64C2B95FC1").IsUnique();

            entity.Property(e => e.ChucVu)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.GhiChu).HasColumnType("text");
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.HocHam)
                .HasMaxLength(10)
                .HasDefaultValue("Không");
            entity.Property(e => e.HocVi)
                .HasMaxLength(20)
                .HasDefaultValue("Khác");
            entity.Property(e => e.MaBoMon)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaGV)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Đang làm việc");

            entity.HasOne(d => d.MaBoMonNavigation).WithMany(p => p.GiangViens)
                .HasPrincipalKey(p => p.MaBoMon)
                .HasForeignKey(d => d.MaBoMon)
                .HasConstraintName("FK__GiangVien__MaBoM__66F53242");

            entity.HasOne(d => d.TaiKhoan).WithOne(p => p.GiangVien)
                .HasForeignKey<GiangVien>(d => d.TaiKhoanID)
                .HasConstraintName("FK__GiangVien__TaiKh__66010E09");

            entity.HasMany(d => d.ID_LinhVucs).WithMany(p => p.MaGVs)
                .UsingEntity<Dictionary<string, object>>(
                    "GiangVien_LinhVuc",
                    r => r.HasOne<LinhVucNghienCuu>().WithMany()
                        .HasForeignKey("ID_LinhVuc")
                        .HasConstraintName("FK__GiangVien__ID_Li__7A0806B6"),
                    l => l.HasOne<GiangVien>().WithMany()
                        .HasPrincipalKey("MaGV")
                        .HasForeignKey("MaGV")
                        .HasConstraintName("FK__GiangVien___MaGV__7913E27D"),
                    j =>
                    {
                        j.HasKey("MaGV", "ID_LinhVuc").HasName("PK__GiangVie__C33AC8B2A1D079BE");
                        j.ToTable("GiangVien_LinhVuc");
                        j.IndexerProperty<string>("MaGV")
                            .HasMaxLength(10)
                            .IsUnicode(false);
                    });
        });

        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Khoa__3214EC275A92323D");

            entity.ToTable("Khoa");

            entity.HasIndex(e => e.MaKhoa, "UQ__Khoa__653904048FBC0048").IsUnique();

            entity.HasIndex(e => e.EmailKhoa, "UQ__Khoa__A7CDAC9A4F8CFB61").IsUnique();

            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.EmailKhoa)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MaKhoa)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.SoDienThoaiKhoa)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TenKhoa).HasMaxLength(100);
        });

        modelBuilder.Entity<LinhVucNghienCuu>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__LinhVucN__3214EC2789235C66");

            entity.ToTable("LinhVucNghienCuu");

            entity.HasIndex(e => e.TenLinhVuc, "UQ__LinhVucN__06AF00010A397536").IsUnique();

            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.TenLinhVuc).HasMaxLength(100);
        });

        modelBuilder.Entity<Lop>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Lop__3214EC27A7D68B2D");

            entity.ToTable("Lop");

            entity.HasIndex(e => e.MaLop, "UQ__Lop__3B98D2729683D73F").IsUnique();

            entity.Property(e => e.GiaoVienChuNhiem)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaLop)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaNganh)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TenLop).HasMaxLength(20);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Đang học");

            entity.HasOne(d => d.GiaoVienChuNhiemNavigation).WithMany(p => p.Lops)
                .HasPrincipalKey(p => p.MaGV)
                .HasForeignKey(d => d.GiaoVienChuNhiem)
                .HasConstraintName("FK__Lop__GiaoVienChu__00B50445");

            entity.HasOne(d => d.MaNganhNavigation).WithMany(p => p.Lops)
                .HasPrincipalKey(p => p.MaNganh)
                .HasForeignKey(d => d.MaNganh)
                .HasConstraintName("FK__Lop__MaNganh__7FC0E00C");
        });

        modelBuilder.Entity<Nganh>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Nganh__3214EC27A6D1C85A");

            entity.ToTable("Nganh");

            entity.HasIndex(e => e.MaNganh, "UQ__Nganh__A2CEF50CF43E33BA").IsUnique();

            entity.Property(e => e.LoaiNganh)
                .HasMaxLength(20)
                .HasDefaultValue("Đại học");
            entity.Property(e => e.MaKhoa)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaNganh)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.TenNganh).HasMaxLength(100);

            entity.HasOne(d => d.MaKhoaNavigation).WithMany(p => p.Nganhs)
                .HasPrincipalKey(p => p.MaKhoa)
                .HasForeignKey(d => d.MaKhoa)
                .HasConstraintName("FK__Nganh__MaKhoa__5A8F5B5D");
        });

        modelBuilder.Entity<NghienCuuKhoaHocSinhVien>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__NghienCu__3214EC2764AF09B3");

            entity.ToTable("NghienCuuKhoaHocSinhVien", tb => tb.HasTrigger("CapNhatFileHoanThanh_NCKH_SV"));

            entity.HasIndex(e => e.MaNCKH, "UQ__NghienCu__2E993BF6CB24512E").IsUnique();

            entity.Property(e => e.DiaDiem).HasMaxLength(200);
            entity.Property(e => e.FileHoanThanh)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.GiangVienHuongDan)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.KetQua).HasMaxLength(100);
            entity.Property(e => e.KinhPhiHoatDong).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.MaNCKH)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TenHoatDong).HasMaxLength(200);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Chờ duyệt");

            entity.HasOne(d => d.GiangVienHuongDanNavigation).WithMany(p => p.NghienCuuKhoaHocSinhViens)
                .HasPrincipalKey(p => p.MaGV)
                .HasForeignKey(d => d.GiangVienHuongDan)
                .HasConstraintName("FK__NghienCuu__Giang__27CED166");
        });

        modelBuilder.Entity<OTP>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__OTP__3214EC279724F317");

            entity.ToTable("OTP");

            entity.Property(e => e.MaOTP)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.ThoiGianHetHan).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianTao).HasColumnType("datetime");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("ChuaSuDung");

            entity.HasOne(d => d.TaiKhoan).WithMany(p => p.OTPs)
                .HasForeignKey(d => d.TaiKhoanID)
                .HasConstraintName("FK__OTP__TaiKhoanID__4964CF5B");
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__SinhVien__3214EC27E80321CF");

            entity.ToTable("SinhVien");

            entity.HasIndex(e => e.MaSV, "UQ__SinhVien__2725081B69D474A2").IsUnique();

            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.MaLop)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaSV)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Đang học");

            entity.HasOne(d => d.MaLopNavigation).WithMany(p => p.SinhViens)
                .HasPrincipalKey(p => p.MaLop)
                .HasForeignKey(d => d.MaLop)
                .HasConstraintName("FK__SinhVien__MaLop__066DDD9B");
        });

        modelBuilder.Entity<SinhVienNCKH>(entity =>
        {
            entity.HasKey(e => new { e.MaNCKH, e.MaSV }).HasName("PK__SinhVien__9CEB6B763D7FBE0A");

            entity.ToTable("SinhVienNCKH");

            entity.Property(e => e.MaNCKH)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaSV)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.KetQuaCaNhan).HasMaxLength(100);
            entity.Property(e => e.VaiTro).HasMaxLength(50);

            entity.HasOne(d => d.MaNCKHNavigation).WithMany(p => p.SinhVienNCKHs)
                .HasPrincipalKey(p => p.MaNCKH)
                .HasForeignKey(d => d.MaNCKH)
                .HasConstraintName("FK__SinhVienN__MaNCK__2AAB3E11");

            entity.HasOne(d => d.MaSVNavigation).WithMany(p => p.SinhVienNCKHs)
                .HasPrincipalKey(p => p.MaSV)
                .HasForeignKey(d => d.MaSV)
                .HasConstraintName("FK__SinhVienNC__MaSV__2B9F624A");
        });

        modelBuilder.Entity<TacGiaCongBo>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__TacGiaCo__3214EC2727C2D36C");

            entity.ToTable("TacGiaCongBo");

            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.MaCongBo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaGV)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaSV)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.MaCongBoNavigation).WithMany(p => p.TacGiaCongBos)
                .HasPrincipalKey(p => p.MaCongBo)
                .HasForeignKey(d => d.MaCongBo)
                .HasConstraintName("FK__TacGiaCon__MaCon__1F398B65");

            entity.HasOne(d => d.MaGVNavigation).WithMany(p => p.TacGiaCongBos)
                .HasPrincipalKey(p => p.MaGV)
                .HasForeignKey(d => d.MaGV)
                .HasConstraintName("FK__TacGiaCong__MaGV__202DAF9E");

            entity.HasOne(d => d.MaSVNavigation).WithMany(p => p.TacGiaCongBos)
                .HasPrincipalKey(p => p.MaSV)
                .HasForeignKey(d => d.MaSV)
                .HasConstraintName("FK__TacGiaCong__MaSV__2121D3D7");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__TaiKhoan__3214EC27B0A4C922");

            entity.ToTable("TaiKhoan");

            entity.HasIndex(e => e.Email, "UQ__TaiKhoan__A9D10534F84E0B05").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MatKhau).HasMaxLength(255);
            entity.Property(e => e.VaiTro).HasMaxLength(255);
        });

        modelBuilder.Entity<TapChiAnPham>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__TapChiAn__3214EC27E41AC63C");

            entity.ToTable("TapChiAnPham");

            entity.HasIndex(e => e.MaAnPham, "UQ__TapChiAn__4260974CB1200194").IsUnique();

            entity.Property(e => e.ISSN_ISBN)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LoaiAnPham)
                .HasMaxLength(50)
                .HasDefaultValue("Khác");
            entity.Property(e => e.MaAnPham)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaGiangVien)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NgonNgu).HasMaxLength(50);
            entity.Property(e => e.NhaXuatBan).HasMaxLength(100);
            entity.Property(e => e.QuocGia).HasMaxLength(50);
            entity.Property(e => e.TenAnPham).HasMaxLength(200);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Đang chờ duyệt");

            entity.HasOne(d => d.MaGiangVienNavigation).WithMany(p => p.TapChiAnPhams)
                .HasPrincipalKey(p => p.MaGV)
                .HasForeignKey(d => d.MaGiangVien)
                .HasConstraintName("FK__TapChiAnP__MaGia__763775D2");
        });

        modelBuilder.Entity<ThanhVienDeTai>(entity =>
        {
            entity.HasKey(e => new { e.MaDeTai, e.MaGV }).HasName("PK__ThanhVie__BDE427B4535A6DAE");

            entity.ToTable("ThanhVienDeTai");

            entity.Property(e => e.MaDeTai)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaGV)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.VaiTro)
                .HasMaxLength(20)
                .HasDefaultValue("Thành viên");

            entity.HasOne(d => d.MaDeTaiNavigation).WithMany(p => p.ThanhVienDeTais)
                .HasPrincipalKey(p => p.MaDeTai)
                .HasForeignKey(d => d.MaDeTai)
                .HasConstraintName("FK__ThanhVien__MaDeT__14BBFCF2");

            entity.HasOne(d => d.MaGVNavigation).WithMany(p => p.ThanhVienDeTais)
                .HasPrincipalKey(p => p.MaGV)
                .HasForeignKey(d => d.MaGV)
                .HasConstraintName("FK__ThanhVienD__MaGV__15B0212B");
        });

        modelBuilder.Entity<TienDo>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__TienDo__3214EC2758BE67E7");

            entity.ToTable("TienDo");

            entity.Property(e => e.FileDinhKem)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MaDeTai)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaNCKH)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NguoiDuyet)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Chờ duyệt");

            entity.HasOne(d => d.MaDeTaiNavigation).WithMany(p => p.TienDos)
                .HasPrincipalKey(p => p.MaDeTai)
                .HasForeignKey(d => d.MaDeTai)
                .HasConstraintName("FK__TienDo__MaDeTai__3805392F");

            entity.HasOne(d => d.MaNCKHNavigation).WithMany(p => p.TienDos)
                .HasPrincipalKey(p => p.MaNCKH)
                .HasForeignKey(d => d.MaNCKH)
                .HasConstraintName("FK__TienDo__MaNCKH__38F95D68");

            entity.HasOne(d => d.NguoiDuyetNavigation).WithMany(p => p.TienDos)
                .HasPrincipalKey(p => p.MaBQL)
                .HasForeignKey(d => d.NguoiDuyet)
                .HasConstraintName("FK__TienDo__NguoiDuy__39ED81A1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
