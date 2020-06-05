using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace ISWebApp.Bot.Base
{

    public class Telegrambot
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("894011227:AAEMS-qnd19xlU7vLtnNLpws-DqjBEaGALQ");
         public  void Executelegram()
         {
            Bot.OnMessage += BotOnMessageReceived;
            Bot.OnCallbackQuery += BotOnCallbackQueryReceived;
            Bot.OnReceiveError += BotOnReceiveError;
            Bot.StartReceiving();
            Bot.StopReceiving();
         }
        private  static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;

            if (message == null || message.Type != MessageType.Text) return;
            
            switch (message.Text.Split(' ').First())
            {

                case "/Sim":
                    await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
                    await Task.Delay(50);
                    var inlineKeyboard = new InlineKeyboardMarkup(new[]
                    {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(
                            text:"Subcrever uma Plano de Viagem",
                            callbackData: "Subcrever uma Plano de Viagem"),
                        InlineKeyboardButton.WithCallbackData(
                            text:"Subcrever uma Apolice",
                            callbackData: "Subcrever uma Apolice"),
                    }
                });

                    //  var planos = DapperContext.GetAsync<PlanoProduto>().Await();

                    // var buttons = planos.Select(s => {
                    //     return InlineKeyboardButton.WithCallbackData(s.Designacao,
                    //      s.IdPlano);
                    // });
                    // var inlineKeyboard = new InlineKeyboardMarkup(buttons);
                  
                    await Bot.SendTextMessageAsync(
                        message.Chat.Id,
                        "Escolha uma opção",
                        replyMarkup: inlineKeyboard);
                    break;

                case "/Nao":
                    var keyboardEjemplo2 = new InlineKeyboardMarkup(new[]
                    {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(
                            text:"Criar Conta",
                            callbackData: "Criar conta"),
                        InlineKeyboardButton.WithCallbackData(
                            text:"Informação Do Sistema",
                            callbackData: "Informação Do Sistema"),
                    }
                });

                    await Bot.SendTextMessageAsync(
                        message.Chat.Id,
                        "Escolha uma opção",
                        replyMarkup: keyboardEjemplo2);
                    break;
                    case "/Info":
                    var keyboardEjempl = new InlineKeyboardMarkup(new[]
                    {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(
                            text:"Informação Da Empresa ",
                            callbackData: "Infor Da Empresa"),

                    }
                   });
                    await Bot.SendTextMessageAsync(
                        message.Chat.Id,
                        "Escolha uma opção",
                        replyMarkup: keyboardEjempl);
                    break;
                
                default:
                const string usage = @"
                Ja tens uma Conta ?:
                /Sim - Opcao  1
                /Nao - Opcao 2
                /Info - Opcao 3
                ";
                

                    await Bot.SendTextMessageAsync(
                        message.Chat.Id,
                        text: usage,
                        replyMarkup: new ReplyKeyboardRemove());

                    break;
            }           
        }

        private static async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs callbackQueryEventArgs)
        {
            var callbackQuery = callbackQueryEventArgs.CallbackQuery;

            switch (callbackQuery.Data)
            {
                case "Criar Conta":
                await Bot.SendTextMessageAsync(
                        chatId: callbackQuery.Message.Chat.Id,
                        text: "Para a criação da Conta da um click neste link :http://172.16.16.15:82/admin/pessoa/add",
                        parseMode: ParseMode.Html
                );
                   
                    break;

                case "Infor Da Empresa":
                const string usage = @"
                LOCALIZAÇÃO:
                    /Pais : Angola;
                    /Provincia : Luanda;
                    /Municipio : Luanda;
                    /Distrito : Urbano da Ingombota;
                    /Andar : 2º andar esquerdo;
                    /Numero da Porta : nº3; 
                    /Rua : Dr. Alves da Cunha;
                    /Numero da Rua : nº 5741
                CONCTACOS: 
                    /Telefone : +244928200100;
                ENDEREÇOS:
                    /Web Site : www.internacionalseguros.co.ao;
                    /E-mail : comercial@internacionalseguros.co.ao;
                    /Skipe ID : internacionalseguros;
                OUTRAS INFORMAÇÃO:
                    /NIF : 5417649945;
                ";

                    await Bot.SendTextMessageAsync(
                      chatId: callbackQuery.Message.Chat.Id,
                        text: usage,
                        replyMarkup: new ReplyKeyboardRemove());

                   
                    break;

                case "Informação Do Sistema":
                    await Bot.SendTextMessageAsync(
                        chatId: callbackQuery.Message.Chat.Id,
                        text: "Para a Obter infomação do sistema da um click neste link : http://172.16.16.15:82/admin/pessoa/add",
                        parseMode: ParseMode.Html
                );
                    break;
                     case "Subcrever uma Plano de Viagem":
                    await Bot.SendTextMessageAsync(
                        chatId: callbackQuery.Message.Chat.Id,
                        text: "Para a Subcrição do Plano de Viagem da um click neste link : http://172.16.16.15:82/admin/generate/FB074EDE-A9A0-45AC-9E4C-377CC7AE474C/Viagens/74018299-17CE-4CB1-85ED-31B1E2EFEFA7add",
                        parseMode: ParseMode.Html
                );
                    break;

               
            }
        }

        private  async void BotOnCallbackQueryRecebida(object sender, CallbackQueryEventArgs callbackQueryEventArgs)
        {
            var callbackQuery = callbackQueryEventArgs.CallbackQuery;
            await Bot.AnswerCallbackQueryAsync(
                callbackQueryId: callbackQuery.Id,
                text: $"Recebida {callbackQuery.Data}"
            );
            await Bot.SendTextMessageAsync(
                chatId: callbackQuery.Message.Chat.Id,
                text: $"Recebida {callbackQuery.Data}"
            );
        }
        private  async void BotOnInlineQueryRecebida(object sender, InlineQueryEventArgs inlineQueryEventArgs)
        {
            Console.WriteLine($"Recebida inline query from: {inlineQueryEventArgs.InlineQuery.From.Id}");
            InlineQueryResultBase[] results = {
                // displayed result
                new InlineQueryResultArticle(
                    id: "3",
                    title: "Snir",
                    inputMessageContent: new InputTextMessageContent(
                        "Ola"
                    )
                )
            };
            await Bot.AnswerInlineQueryAsync(
                inlineQueryId: inlineQueryEventArgs.InlineQuery.Id,
                results: results,
                isPersonal: true,
                cacheTime: 0
            );
        }
        private static void BotOnReceiveError(object sender, ReceiveErrorEventArgs receiveErrorEventArgs)
        {
            Console.WriteLine("Recebida error: {0} — {1}",
                receiveErrorEventArgs.ApiRequestException.ErrorCode,
                receiveErrorEventArgs.ApiRequestException.Message
            );
        }
    }
}