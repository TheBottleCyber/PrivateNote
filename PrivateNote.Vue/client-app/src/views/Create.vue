<template>
  <div class="create">
    <div class="container-fluid">
      <div class="row justify-content-md-center">
        <div class="form-group col-md-6">
          <input id="inputHash" v-model="noteHash" placeholder="There will be your hash" class="form-control" required="required">
          <br>
          <textarea id="createNoteFormControlTextarea" placeholder="Enter note" v-model="noteText" class="form-control" rows="6"></textarea>
        </div>

        
      </div>

      <div class="justify-content-md-center ">
        <button type="button" class="btn btn-primary" v-on:click="createNote">Create</button>
      </div>

    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: 'Create',
  data(){
    return {
      noteText : '',
      noteHash: ''
    }
  },
  methods: {
    createNote: async function () {
      let bodyFormData = new FormData();
      bodyFormData.append("noteString", this.noteText);
      
      const data = await axios({
        method: "post",
        url: 'https://localhost:35050/addNote',
        data: bodyFormData,
        headers: {"Content-Type": "multipart/form-data"},
      });
      
      this.noteHash = data.data;
    }
  }
}
</script>
