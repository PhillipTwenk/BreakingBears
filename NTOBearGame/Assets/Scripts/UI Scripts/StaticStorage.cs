using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StaticStorage : MonoBehaviour
{
    public static Text ProgressPanelTextStatic;
    public static TextMeshProUGUI DetailPanelTextStatic;
    public Text ProgressPanelText;
    public TextMeshProUGUI DetailPanelText;
    public static bool isChatRead;
    public GameObject textObjectB, textObjectL;
    public GameObject TextingMessageAnimationObj;
    public static GameObject TextingMessageAnimationObjStatic;
    public static GameObject textObjectPrefabB, textObjectPrefabL;
    public static string[] AllMessagesArray;
    public ChatSystem ChatSystemRef;
    public static ChatSystem ChatSystemRefStatic;
    void Start()
    {
        ChatSystemRefStatic = ChatSystemRef;
        AllMessagesArray = new string[47];
        AssigningValues();
        TextingMessageAnimationObjStatic = TextingMessageAnimationObj;
        ProgressPanelTextStatic = ProgressPanelText;
        DetailPanelTextStatic = DetailPanelText;
        textObjectPrefabB = textObjectB;
        textObjectPrefabL = textObjectL;
    }
    private void AssigningValues()
    {
        AllMessagesArray[0] = "Здравствуй, Борислав!";
        AllMessagesArray[1] = "Ты как всегда в лаборатории? Трудишься не покладая рук. Но пришло время обсудить наше новое задание";
        AllMessagesArray[2] = "Как ты помнишь, мы медленно, но верно двигаемся к созданию эликсира, который изменит жизнь и историю всех медведей на планете";
        AllMessagesArray[3] = "Сегодня даю тебе задание на создание вещества для синтезирования эликсира. Для этого придётся немного прогуляться, а то ты не вылезаешь из лаборатории";
        AllMessagesArray[4] = "Итак, я выслал тебе на очки несколько полезных инструментов, один из которых карта";
        AllMessagesArray[5] = "На ней указано строение подземелья, где и предстоит добыть все необходимые вещества для выполнения задачи";
        AllMessagesArray[6] = "Синим цветом отмечены зоны с разнообразными ловушками, которые нужно пройти";
        AllMessagesArray[7] = "А вот красным обозначены более коварные места. Там нет ловушек, но опасность представляет само наполнение";
        AllMessagesArray[8] = "Такие зоны наполнены ядовитыми испарениями, и прежде чем туда пойти, тебе придётся создать для себя противоядие";
        AllMessagesArray[9] = "Пора начинать!";
        AllMessagesArray[10] = "Высланная мной карта соединена с телепортатором, для открытия точек телепортации  достаточно один раз войти в зону их действия";
        AllMessagesArray[11] = "Помимо этого, они могут спасти твою шкуру. Когда система чувствует крайнюю угрозу она телепортирует тебя на последнюю открытую тобой точку";
        AllMessagesArray[12] = "Для начала открой карту (Кнопка с обозначением метки) и используй уже открытую тобой первую метку";
        AllMessagesArray[13] = "Последовательность локаций идёт сверху вниз";
        AllMessagesArray[14] = "Напишу тебе, как достигнешь конца первого уровня. Удачи";
        AllMessagesArray[15] = "Смотрю, ты справился, прекрасно! Далее тебе необходимо войти в портал, они соединяют уровни подземелья между собой";
        AllMessagesArray[16] = "Здесь и располагаются точки телепортации и хранилища с нужными нам веществами";
        AllMessagesArray[17] = "Нажми на них и выпадут нужные вещества, положи их к себе в инвентарь";
        AllMessagesArray[18] = "Пора возвращаться. Открой карту и нажми на точку телепортации лаборатории,  вернёшься обратно к себе, затворник:)";
        AllMessagesArray[19] = "Ах да, совсем забыл рассказать, как создавать вещества ";
        AllMessagesArray[20] = "Для начала зайди в карту, там будет подписано, какое противоядие создавать против ядовитой зоны, это мы уже исследовали";
        AllMessagesArray[21] = "Вторым инструментом, который я тебе выслал, является справочник";
        AllMessagesArray[22] = "Тут расписаны все реакции, которые понадобятся в создании всех противоядий и нужного нам вещества";
        AllMessagesArray[23] = "Знаю, знаю, даже для тебя там сложно разобраться, но я немного помогу тебе с этим";
        AllMessagesArray[24] = "Для начала посмотри, как создаётся противоядие, выбери в выпадающем списке нужный тебе элемент, нам будут написаны реакции, в которых он создаётся";
        AllMessagesArray[25] = "Дальше посмотри, какие элементы ты добыл, и какие реакции ты можешь составить для получения нужного тебе элемента";
        AllMessagesArray[26] = "Думаю,  я подскажу тебе в первый раз";
        AllMessagesArray[27] = "Ты должен был получить Na, H2O и Cl";
        AllMessagesArray[28] = "По справочнику нужное тебе противоядие(NaClO, кажется) можно создать по такой реакции:";
        AllMessagesArray[29] = "NaOH + Cl = NaClO + H2O";
        AllMessagesArray[30] = "Для создания нам не хватает NaOH, но в нашем справочнике есть нужная нам реакция(раздел Na)";
        AllMessagesArray[31] = "Na + H2O = NaOH";
        AllMessagesArray[32] = "Как видишь всё просто. Для обучения работы с новым оборудованием я выслал тебе небольшую презентацию. Удачи в работе";
        AllMessagesArray[33] = "Вау, ты смог получить элемент, мои поздравления!";
        AllMessagesArray[34] = "Теперь пора использовать наше противоядие на практике. Переместись в то же место, откуда взял элементы, там находится точка телепортации";
        AllMessagesArray[35] = "Подойди к порталу поближе, но сразу не входи, сначала достань противоядие из инвентаря и используй его на себе";
        AllMessagesArray[36] = "А теперь беги в портал!  Действие противоядия ограничено, поэтому поторопись прямо сейчас! Сразу беги в портал, напишу тебе после твоего прохождения";
        AllMessagesArray[37] = "Смотрю ты живой, какое счастье, ха-ха! Хотя в любом случае тебя бы спасла система";
        AllMessagesArray[38] = "Следующий уровень ждёт тебя";
        AllMessagesArray[39] = "Напишу как вернёшься в лабораторию с новыми элементами";
        AllMessagesArray[40] = "Ты снова в лаборатории, отлично";
        AllMessagesArray[41] = "У меня совсем немного времени тебе писать, сейчас пойду на конференцию как раз по вопросу эликсира";
        AllMessagesArray[42] = "Подскажу лишь, что формулы нужно искать в разделах противоядия(Для второй ядовитой зоны) и в разделе Na";
        AllMessagesArray[43] = "Прости, сейчас я буду на конференции, долго не смогу отвечать , надеюсь ты справишься";
        AllMessagesArray[44] = "И совсем забыл сказать, нам нужно создать Li2CO3, с его созданием я уже не смогу помочь, но ты смышлёный, справишься";
        AllMessagesArray[45] = "Снова здравствуй! Я получил информацию о том что ты закончил создание последнего элемента, ты проделал огромную работу";
        AllMessagesArray[46] = "Я пришлю курьера за этим веществом, а пока можешь уделить это время себе";
        AllMessagesArray[46] = "До связи!";
    }

}
