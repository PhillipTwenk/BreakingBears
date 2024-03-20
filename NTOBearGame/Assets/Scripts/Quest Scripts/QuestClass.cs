using UnityEngine;


public class QuestClass
    {
        public void TextChanger(){
            
            // Получение значения, отображающего наше продвижение в квесте и продвижение в сообщениях

            int Progress = PlayerPrefs.GetInt("ProgressInt");

            string SmallPanelQuery = $"SELECT SmallPanel FROM Panel_Table WHERE id = '{Progress}'";
            string DetailPanelQuery = $"SELECT DetailedPanel FROM Panel_Table WHERE id = '{Progress}'";

            StaticStorage.ProgressPanelTextStatic.text = DBManager.ExecuteQuery(SmallPanelQuery);
            StaticStorage.DetailPanelTextStatic.text = DBManager.ExecuteQuery(DetailPanelQuery);
            StaticStorage.TextHelperQuestStatic.text = DBManager.ExecuteQuery(SmallPanelQuery);
            SendQuestMessage(Progress);
        }

        //Отправка сообщений, если на текущем квесте это необходимо
        public void SendQuestMessage(int progress){

            //Получение информации о том, нужно ли отправлять сообщение на текущем квесте

            string QueryBoolMessage = $"SELECT AreThereMessages FROM Panel_Table WHERE id = '{progress}'".ToString();
            bool AreThereMessagesOnTheQuest = bool.Parse(DBManager.ExecuteQuery(QueryBoolMessage));

            //Проверка

            if(AreThereMessagesOnTheQuest){

                //Получение информации о том, какой номер прогресса сообщений в текущем квесте

                string MessageQueryNumber = $"SELECT MessageNumber FROM QuestsWithMessages WHERE QuestNumber = '{progress}'";

                //Запуск корутины с отправкой сообщений
                StaticStorage.ChatSystemRefStatic.StartCoroutineMethod(int.Parse(DBManager.ExecuteQuery(MessageQueryNumber)));
            }
        }
        
        //Cnарт нового квеста
        public void StartNewQuest(int ActiveQuest){
            PlayerPrefs.SetInt("ProgressInt", ActiveQuest + 1);
            TextChanger();
            Debug.Log($"{ActiveQuest} квест выполнен! ");
        }
        
        //Проверка на текущий квест
        public void CheckQuest(int CurrentQuestStage)
        {
            if (PlayerPrefs.GetInt("ProgressInt") == CurrentQuestStage && !TutorialClass.IsInTutorial)
            {
                StartNewQuest(CurrentQuestStage);
            }
        }
    }


