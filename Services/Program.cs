using Services;
using Services.Settings;

Console.WriteLine("=== Sistema de Configurações ===\n");

Console.WriteLine("Inicializando serviços...\n");

var dbService = new DatabaseService();
var apiService = new ApiService();
var cacheService = new CacheService();
var logService = new LoggingService();

Console.WriteLine("\nUsando os serviços...\n");

dbService.Connect();
apiService.MakeRequest();
cacheService.Connect();
logService.Log("Sistema iniciado");


Console.WriteLine("\n--- Tentativa de atualização ---\n");

var config1 = ConfigurationManager.Instance;
config1.LoadConfigurations();
config1.UpdateSetting("LogLevel", "Debug");

var config2 = ConfigurationManager.Instance;
config2.LoadConfigurations();
Console.WriteLine($"Config1 LogLevel: {config1.GetSetting("LogLevel")}");
Console.WriteLine($"Config2 LogLevel: {config2.GetSetting("LogLevel")}");
Console.WriteLine("⚠️ Inconsistência: Instâncias diferentes têm valores diferentes!");

Console.WriteLine("\n--- Impacto de Performance ---");
Console.WriteLine("Cada serviço carregou as configurações separadamente");
Console.WriteLine("Isso multiplica o uso de memória e tempo de inicialização");