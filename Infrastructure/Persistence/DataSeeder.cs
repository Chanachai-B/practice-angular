using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public static class DataSeeder
{
    public static async Task SeedAsync(ApplicationDbContext db)
    {
        if (await db.Set<User>().AnyAsync()) return;

        db.Set<User>().AddRange(
            new User { Name = "สมชาย",   Lastname = "ใจดี",       Address = "123 ถ.สุขุมวิท กรุงเทพฯ",           Dob = new DateOnly(1990,  5, 15) },
            new User { Name = "สมหญิง",  Lastname = "รักเรียน",   Address = "456 ถ.พระราม 9 กรุงเทพฯ",           Dob = new DateOnly(1995,  8, 22) },
            new User { Name = "วิชัย",   Lastname = "มั่นคง",     Address = "789 ถ.เชียงใหม่-ลำปาง เชียงใหม่",  Dob = new DateOnly(1988,  3, 10) },
            new User { Name = "นภา",     Lastname = "สว่างใจ",    Address = "321 ถ.นิมมานเหมินทร์ เชียงใหม่",   Dob = new DateOnly(1992,  1, 30) },
            new User { Name = "ประเสริฐ",Lastname = "ทองดี",      Address = "654 ถ.มิตรภาพ ขอนแก่น",            Dob = new DateOnly(1985, 11,  5) },
            new User { Name = "มาลี",    Lastname = "ดอกไม้",     Address = "987 ถ.ราชดำเนิน กรุงเทพฯ",          Dob = new DateOnly(1998,  6, 18) },
            new User { Name = "อนุชา",   Lastname = "พรมมา",      Address = "111 ถ.เพชรเกษม กรุงเทพฯ",           Dob = new DateOnly(1993,  9, 25) },
            new User { Name = "รัตนา",   Lastname = "ศรีสุข",     Address = "222 ถ.สีลม กรุงเทพฯ",               Dob = new DateOnly(1996,  4,  8) },
            new User { Name = "กิตติ",   Lastname = "วงศ์สว่าง",  Address = "333 ถ.บางนา กรุงเทพฯ",              Dob = new DateOnly(1987,  7, 14) },
            new User { Name = "ชลิตา",   Lastname = "เพชรรัตน์",  Address = "444 ถ.ลาดพร้าว กรุงเทพฯ",          Dob = new DateOnly(2000,  2, 28) },
            new User { Name = "ธนา",     Lastname = "สมบูรณ์",    Address = "555 ถ.รัชดาภิเษก กรุงเทพฯ",        Dob = new DateOnly(1991, 12,  3) },
            new User { Name = "พิมพ์",   Lastname = "ใจงาม",      Address = "666 ถ.วิภาวดี กรุงเทพฯ",            Dob = new DateOnly(1994, 10, 20) },
            new User { Name = "สุรชัย",  Lastname = "แก้วมณี",    Address = "777 ถ.อโศก กรุงเทพฯ",               Dob = new DateOnly(1983,  8,  7) },
            new User { Name = "นิตยา",   Lastname = "หอมจันทร์",  Address = "888 ถ.ทองหล่อ กรุงเทพฯ",            Dob = new DateOnly(1997,  3, 16) },
            new User { Name = "ชัยวัฒน์",Lastname = "บุญเลิศ",    Address = "999 ถ.เอกมัย กรุงเทพฯ",             Dob = new DateOnly(1986,  5, 23) },
            new User { Name = "ลลิตา",   Lastname = "ศิริพงษ์",   Address = "101 ถ.สาทร กรุงเทพฯ",               Dob = new DateOnly(1999,  1, 11) },
            new User { Name = "ภาณุ",    Lastname = "ดวงดี",      Address = "202 ถ.สุรวงศ์ กรุงเทพฯ",            Dob = new DateOnly(1989,  6,  4) },
            new User { Name = "อรุณี",   Lastname = "จันทร์งาม",  Address = "303 ถ.เจริญกรุง กรุงเทพฯ",         Dob = new DateOnly(1993, 11, 19) },
            new User { Name = "พงษ์ศักดิ์",Lastname = "ทวีสุข",  Address = "404 ถ.บางรัก กรุงเทพฯ",             Dob = new DateOnly(1982,  4,  2) },
            new User { Name = "สิริมา",  Lastname = "ประทุม",     Address = "505 ถ.ป้อมปราบ กรุงเทพฯ",           Dob = new DateOnly(2001,  9, 30) },
            new User { Name = "วรวุฒิ",  Lastname = "พันธ์ดี",    Address = "606 ถ.บึงกุ่ม กรุงเทพฯ",            Dob = new DateOnly(1996,  7, 13) },
            new User { Name = "กนกวรรณ", Lastname = "สุขสม",      Address = "707 ถ.รามคำแหง กรุงเทพฯ",           Dob = new DateOnly(1990, 12, 26) },
            new User { Name = "เอกชัย",  Lastname = "มีสุข",      Address = "808 ถ.เสรีไทย กรุงเทพฯ",            Dob = new DateOnly(1984,  2, 17) },
            new User { Name = "วันเพ็ญ", Lastname = "แสงทอง",     Address = "909 ถ.หทัยราษฎร์ กรุงเทพฯ",        Dob = new DateOnly(1997,  8,  9) },
            new User { Name = "ปิยะ",    Lastname = "รุ่งเรือง",  Address = "100 ถ.สะพานสูง กรุงเทพฯ",           Dob = new DateOnly(1991,  3, 21) }
        );

        await db.SaveChangesAsync();
    }
}