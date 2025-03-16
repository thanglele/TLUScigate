using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using TLUScience.DTOs;
using TLUScience.Entities;
using TLUScience.Interface;

public interface IBaoCaoThongKeService
{
    public Task<bool> AddBaoCaoThongKeAsync(BaoCaoThongKeCRUD baoCaoThongKe, int idNguoiLap);
    Task<byte[]> ExportBaoCaoToPdfAsync(int id);
    Task<byte[]> ExportBaoCaoToExcelAsync(int idBaoCao);

}

public class BaoCaoThongKeService : IBaoCaoThongKeService
{
    private readonly IBaoCaoThongKeRepository _baoCaoThongKeRepository;

    public BaoCaoThongKeService(IBaoCaoThongKeRepository baoCaoThongKeRepository)
    {
        _baoCaoThongKeRepository = baoCaoThongKeRepository;
    }

    public async Task<bool> AddBaoCaoThongKeAsync(BaoCaoThongKeCRUD baoCaoThongKe, int idNguoiLap)
    {
        var baoCaoThongKeEntity = new BaoCaoThongKe
        {
            MaBaoCao = baoCaoThongKe.MaBaoCao,
            TenBaoCao = baoCaoThongKe.TenBaoCao,
            LoaiBaoCao = baoCaoThongKe.LoaiBaoCao,
            ThoiGianBatDau = baoCaoThongKe.ThoiGianBatDau,
            ThoiGianKetThuc = baoCaoThongKe.ThoiGianKetThuc,
            NoiDung = baoCaoThongKe.NoiDung,
            NguoiLap = idNguoiLap,
            NgayLap = DateOnly.FromDateTime(DateTime.Now),
            DuongDanFile = baoCaoThongKe.DuongDanFile,
            TrangThaiDuyet = baoCaoThongKe.TrangThai
        };
        await _baoCaoThongKeRepository.AddBaoCaoThongKeAsync(baoCaoThongKeEntity);
        return true;
    }

    public async Task<byte[]> ExportBaoCaoToPdfAsync(int id)
    {
        var baoCao = await _baoCaoThongKeRepository.GetBaoCaoThongKeAsync(id);
        if (baoCao == null)
            return null;

        using (var memoryStream = new MemoryStream())
        {
            Document document = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            // Font chữ
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fontTitle = new Font(bf, 18, Font.BOLD);
            Font fontContent = new Font(bf, 12, Font.NORMAL);

            // Tiêu đề
            document.Add(new Paragraph("Báo Cáo Thống Kê", fontTitle));
            document.Add(new Paragraph("-----------------------------------------------------"));
            document.Add(new Paragraph($"Mã báo cáo: {baoCao.MaBaoCao}", fontContent));
            document.Add(new Paragraph($"Tên báo cáo: {baoCao.TenBaoCao}", fontContent));
            document.Add(new Paragraph($"Loại báo cáo: {baoCao.LoaiBaoCao}", fontContent));
            document.Add(new Paragraph($"Thời gian bắt đầu: {baoCao.ThoiGianBatDau:dd/MM/yyyy}", fontContent));
            document.Add(new Paragraph($"Thời gian kết thúc: {baoCao.ThoiGianKetThuc:dd/MM/yyyy}", fontContent));
            document.Add(new Paragraph($"Nội dung: {baoCao.NoiDung}", fontContent));

            document.Close();
            return memoryStream.ToArray();
        }
    }

    public async Task<byte[]> ExportBaoCaoToExcelAsync(int idBaoCao)
    {
        var baoCao = await _baoCaoThongKeRepository.GetBaoCaoThongKeAsync(idBaoCao);
        if (baoCao == null) return null;
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("Báo Cáo");

            worksheet.Cells["A1"].Value = "Mã Báo Cáo";
            worksheet.Cells["B1"].Value = "Tên Báo Cáo";
            worksheet.Cells["C1"].Value = "Loại Báo Cáo";
            worksheet.Cells["D1"].Value = "Thời Gian Bắt Đầu";
            worksheet.Cells["E1"].Value = "Thời Gian Kết Thúc";
            worksheet.Cells["F1"].Value = "Nội Dung";
            worksheet.Cells["G1"].Value = "Đường Dẫn File";
            worksheet.Cells["H1"].Value = "Trạng Thái";

            worksheet.Cells["A2"].Value = baoCao.MaBaoCao;
            worksheet.Cells["B2"].Value = baoCao.TenBaoCao;
            worksheet.Cells["C2"].Value = baoCao.LoaiBaoCao;
            worksheet.Cells["D2"].Value = baoCao.ThoiGianBatDau.HasValue 
                ? baoCao.ThoiGianBatDau.Value.ToDateTime(TimeOnly.MinValue).ToString("yyyy-MM-dd") 
                : string.Empty;
            worksheet.Cells["E2"].Value = baoCao.ThoiGianKetThuc.HasValue 
                ? baoCao.ThoiGianKetThuc.Value.ToDateTime(TimeOnly.MinValue).ToString("yyyy-MM-dd") 
                : string.Empty;
            worksheet.Cells["F2"].Value = baoCao.NoiDung;
            worksheet.Cells["G2"].Value = baoCao.DuongDanFile;
            worksheet.Cells["H2"].Value = baoCao.TrangThaiDuyet;

            worksheet.Cells.AutoFitColumns();

            return package.GetAsByteArray();
        }
    }
}